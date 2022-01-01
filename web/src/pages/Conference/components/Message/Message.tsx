import React from "react";
import "./Message.sass";
import dayjs from "dayjs";
import { IMessage } from "../../../../core/types";

type MessageProps = {
    message: IMessage;
}

export const Message: React.FC<MessageProps> = ({ message }: MessageProps) => {
    return <div className="message">
        <p className="message__login">@{message.user.login}</p>
        <p className="message__text">{message.text}</p>
        <div className="message__date">
            <p>{dayjs(message.createdAt).format("HH:mm D-MMM-YYYY")}</p>
        </div>
    </div>;
}
