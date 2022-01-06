import React from "react";
import "./Title.sass";

type TitleProps = { text: string };

export const Title = ({ text }: TitleProps) => {
    return <h2 className="title">{text}</h2>
}
