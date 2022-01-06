import React, { FC } from "react";
import "./Home.sass";
import { FeedBoard } from "./components/FeedBoard/FeedBoard";
import { Board } from "../../shared/components/Board/Board";
import { InvitationBoard } from "./components/InvitationBoard/InvitationBoard";
import { YourBoard } from "./components/YourBoard/YourBoard";
import {CreateBoard} from "./components/CreateBoard/CreateBoard";

export const Home: FC = () => {
    return (
        <div className="home-page">
            <div className="home-page__feed-menu-wrapper">
                <Board content={<CreateBoard />} />
                <Board content={<FeedBoard />} />
            </div>
            <div className="home-page__personal-menu-wrapper">
                <InvitationBoard />
                <YourBoard />
            </div>
        </div>
    );
};
