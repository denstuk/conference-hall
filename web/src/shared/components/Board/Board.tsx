import React from "react";
import "./Board.sass";

type BoardProps = {
    content: React.ReactNode;
};

export const Board: React.FC<BoardProps> = ({ content }: BoardProps) => {
    return <div className="board">{content}</div>;
};
