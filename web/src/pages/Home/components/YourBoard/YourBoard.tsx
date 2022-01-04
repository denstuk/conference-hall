import React from "react";
import { ConferenceList } from "../../../../shared/components/ConferenceList/ConferenceList";
import "./YourBoard.sass";
import {ConferenceMocker} from "../../../../shared/lib/mocks/conferences";

export const YourBoard: React.FC = () => {
    return (
        <div className="your-board">
            <div className="your-board__header">
                <h2 className="your-board__title">Your Conferences</h2>
                <div className="your-board__notifications">5</div>
            </div>
            <ConferenceList conferences={ConferenceMocker.many(5)} />
        </div>
    );
};
