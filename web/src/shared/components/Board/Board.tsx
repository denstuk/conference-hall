import React, { FC } from "react";
import "./Board.sass";

type BoardProps = {
    content: React.ReactNode;
};

export const Board: FC<BoardProps> = ({ content }: BoardProps) => {
    return <div className="board">{content}</div>;
};
