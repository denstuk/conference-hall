import React from "react";
import "./Page.sass";
import { Header } from "../Header/Header";

type IPageProps = {
    content: React.ReactNode;
};

export const Page: React.FC<IPageProps> = ({ content }: IPageProps) => {
    return (
        <div className="page">
            <Header />
            <div className="page__content">{content}</div>
        </div>
    );
};
