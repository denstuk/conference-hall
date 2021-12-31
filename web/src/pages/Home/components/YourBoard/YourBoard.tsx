import faker from "faker";
import React from "react";
import { IConference } from "../../../../core/conferences/types";
import { ConferenceList } from "../../../../shared/components/ConferenceList/ConferenceList";
import "./YourBoard.sass";

export const YourBoard: React.FC = () => {
    const conferences: IConference[] = [];
    for (let i = 0; i < 5; i++) {
        conferences.push({ id: String(i), title: faker.random.words(10), createdAt: faker.date.past() });
    }

    return (
        <div className="your-board">
            <div className="your-board__header">
                <h2 className="your-board__title">Your Conferences</h2>
                <div className="your-board__notifications">5</div>
            </div>
            <ConferenceList conferences={conferences} />
        </div>
    );
};
