import React, { useEffect, useState } from "react";
import "./Conference.sass";
import faker from "faker";
import { Message } from "./components/Message/Message";
import { useParams } from "react-router-dom";
import { HttpTransportType, HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { IMessage } from "../../core";
import { LocalStorage } from "../../shared/lib/providers/local-storage";
import { StorageKey } from "../../core/constants";
import { MessagesAPI } from "../../shared/api";
import FA from "react-fontawesome";

export const Conference: React.FC = () => {
    const { id } = useParams();
    const [connection, setConnection] = useState<HubConnection>();
    const [title] = useState(faker.random.words(5));
    const [messages, setMessages] = useState<IMessage[]>([]);
    const [inputMessage, setInputMessage] = useState("");

    useEffect(() => {
        const fetchMessages = async (): Promise<void> => {
            const fetchedMessages = await MessagesAPI.search({ conferenceId: id! });
            setMessages([...fetchedMessages]);
        }
        if (!connection) joinRoom().then(() => fetchMessages()).then();
    });

    const joinRoom = async () => {
        const connection = new HubConnectionBuilder()
            .withUrl("https://localhost:44391/chatHub", {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets,
            })
            .configureLogging(LogLevel.Information)
            .build();
        connection.on("ReceiveMessage", (message: IMessage) => {
            console.log(message);
            setMessages((messages) => [message, ...messages]);
        });
        await connection.start();
        await connection.invoke("Join", {
            ConferenceId: id,
            Token: LocalStorage.get(StorageKey.AccessToken),
        });
        setConnection(connection);
    };

    const sendMessage = async (e: React.FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();
        if (connection) {
            await connection.invoke("SendMessage", { Text: inputMessage });
            setInputMessage("");
        }
    };

    return (
        <div className="conference-page">
            <div className="conference-page__title">
                <p>{title}</p>
            </div>
            <div className="conference-page__messages">
                {messages.map((m) => (
                    <Message key={m.id} message={m} />
                ))}
            </div>
            <div className="conference-page__connections">
                <button><FA name="microphone" /></button>
            </div>
            <form onSubmit={(e) => sendMessage(e)} className="conference-page__input">
                <input autoComplete="off" name="message" value={inputMessage} onChange={(e) => setInputMessage(e.target.value)} />
            </form>
        </div>
    );
};
