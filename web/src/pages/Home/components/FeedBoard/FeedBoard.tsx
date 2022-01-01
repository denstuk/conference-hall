import React from "react";
import { ConferenceList } from "../../../../shared/components/ConferenceList/ConferenceList";
import { ConferenceMocker } from "../../../../shared/mocks/conferences";

export const FeedBoard: React.FC = () => {
    return <div>
        <div className="your-board__header">
            <h2 className="your-board__title">Last Conferences</h2>
        </div>
        <ConferenceList conferences={ConferenceMocker.many(10)} />
    </div>;
};
