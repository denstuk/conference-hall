import React from "react";
import "./BoardTitle.sass";

type IBoardTitleProps = {
    emoji?: string;
    title: string;
};

export const BoardTitle: React.FC<IBoardTitleProps> = ({ title, emoji }: IBoardTitleProps) => {
    return (
        <div className="board-title">
            <h3>{emoji ?? ""}</h3>
            <h2>{title}</h2>
        </div>
    );
};
