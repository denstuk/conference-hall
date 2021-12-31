import React from "react";
import { IConference } from "../../../../core/conferences/types";
import { ConferenceList } from "../../../../shared/components/ConferenceList/ConferenceList";
import faker from "faker";

export const FeedBoard: React.FC = () => {
    const conferences: IConference[] = [];
    for (let i = 0; i < 15; i++) {
        conferences.push({ id: String(i), title: faker.random.words(10), createdAt: faker.date.past() });
    }

    return (
        <div>
            <div className="your-board__header">
                <h2 className="your-board__title">Last Conferences</h2>
            </div>
            <ConferenceList conferences={conferences} />
        </div>
    );
};
