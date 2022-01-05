import React, {useEffect, useState} from "react";
import "./Conference.sass";
import faker from "faker";
import {Message} from "./components/Message/Message";
import {MessageMocker} from "../../shared/lib/mocks/messages";
import {useNavigate, useParams} from "react-router-dom";
import {useAppSelector} from "../../shared/store";
import {HttpTransportType, HubConnection, HubConnectionBuilder, LogLevel} from "@microsoft/signalr";
import {IMessage} from "../../core";
import {LocalStorage} from "../../shared/lib/providers/local-storage";
import {StorageKey} from "../../core/constants";

export const Conference: React.FC = () => {
    const [connection, setConnection] = useState<HubConnection>();
    const [title] = useState(faker.random.words(5));
    const [messages, setMessages] = useState(MessageMocker.many(2));
    const [inputMessage, setInputMessage] = useState("");

    const navigate = useNavigate();
    const { id } = useParams();
    const state = useAppSelector((state) => state.authReducer);

    useEffect(() => {
        if (!state.authorized) {
            navigate("/auth?sign-in")
        }
        if (!connection) joinRoom();
    });

    const joinRoom = async () => {
        const connection = new HubConnectionBuilder()
            .withUrl("https://localhost:44391/chatHub", { skipNegotiation: true, transport: HttpTransportType.WebSockets })
            .configureLogging(LogLevel.Information)
            .build();
        connection.on("ReceiveMessage", (message: IMessage) => {
            console.log(message)
            setMessages(messages => [message, ...messages]);
        });
        await connection.start();
        await connection.invoke("Join", {
            ConferenceId: id,
            Token: LocalStorage.get(StorageKey.AccessToken),
        });
        setConnection(connection);
    }

    const sendMessage = async (e: React.FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();
        if (connection) {
            await connection.invoke("SendMessage", { Text: inputMessage });
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
            <form onSubmit={(e) => sendMessage(e)} className="conference-page__input">
                <input name="message" onChange={(e) => setInputMessage(e.target.value)} />
            </form>
        </div>
    );
};
