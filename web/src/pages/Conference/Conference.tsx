import React from "react";
import "./Conference.sass";
import faker from "faker";
import { Message } from "./components/Message/Message";
import { MessageMocker } from "../../shared/mocks/messages";

export const Conference: React.FC = () => {
    // const { id } = useParams(); TODO:Development
    const title: string = faker.random.words(5);

    return <div className="conference-page">
        <div className="conference-page__title">
            <p>{title}</p>
        </div>
        <div className='conference-page__messages'>
            { MessageMocker.many(50).map((m) => <Message message={m} />) }
        </div>
        <input className="conference-page__input" />
    </div>;
};
