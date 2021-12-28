import React, {FC} from "react";
import "./Home.sass"
import {Navigation} from "../../shared/components/Navigation/Navigation";
import {LastConferencesBoard} from "./components/LastConferencesBoard/LastConferencesBoard";

export const Home: FC = () => {
    return <div className="home-page">
        <div className="home-page__row">
            <Navigation />
        </div>
        <LastConferencesBoard />
    </div>
}
