import React, { useState } from "react";
import "./Conference.sass";
import faker from "faker";
import { Message } from "./components/Message/Message";
import { MessageMocker } from "../../shared/lib/mocks/messages";

export const Conference: React.FC = () => {
    // const { id } = useParams(); TODO:Development
    const [title] = useState(faker.random.words(5));
    const [messages, setMessages] = useState(MessageMocker.many(2));
    const [inputMessage, setInputMessage] = useState("");

    const sendMessage = async (e: React.FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();
        setMessages([
            {
                id: "newmessage" + String(messages.length + 1),
                text: inputMessage,
                createdAt: new Date(),
                user: {
                    id: String(1),
                    login: "denstuk",
                    email: "denstuk@example.com",
                    role: 2,
                    createdAt: new Date(),
                },
            },
            ...messages,
        ]);
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
