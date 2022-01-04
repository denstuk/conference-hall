import React from "react";
import "./FeedBoard.sass";
import { ConferenceList } from "../../../../shared/components/ConferenceList/ConferenceList";
import FA from "react-fontawesome";
import { ConferenceMocker } from "../../../../shared/lib/mocks/conferences";

export const FeedBoard: React.FC = () => {
    return (
        <div className="feed-board">
            <div className="your-board__header">
                <h2 className="your-board__title">Last Conferences</h2>
            </div>
            <div className="feed-board__bar">
                <div className="feed-board__search-bar">
                    <FA name="search" />
                    <input />
                </div>
                <div className="feed-board__pagination">
                    <button>
                        <FA name="chevron-left" />
                    </button>
                    <p>1</p>
                    <button>
                        <FA name="chevron-right" />
                    </button>
                </div>
            </div>
            <ConferenceList conferences={ConferenceMocker.many(10)} />
        </div>
    );
};
