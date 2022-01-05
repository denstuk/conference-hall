import React, {useEffect, useState} from "react";
import "./FeedBoard.sass";
import { ConferenceList } from "../../../../shared/components/ConferenceList/ConferenceList";
import FA from "react-fontawesome";
import {ConferencesAPI} from "../../../../shared/api/conferences";
import {IConference} from "../../../../core";
import TailSpin from "react-loader-spinner";

const DEFAULT_STEP = 5;

export const FeedBoard: React.FC = () => {
    const [loading, setLoading] = useState(true);
    const [conferences, setConferences] = useState<IConference[]>([]);
    const [page, setPage] = useState(0);

    useEffect(() => {
       const fetchConferences = async () => {
           const fetched = await ConferencesAPI.search();
           setConferences([...fetched]);
           setTimeout(() => setLoading(false), 1000)
       }
       fetchConferences().then();
    }, []);

    const incrementPage = () => {
        if (!conferences) return;
        const max = Math.floor(conferences.length / DEFAULT_STEP) + (conferences.length % DEFAULT_STEP === 0 ? -1 : 0);
        return setPage(Math.min(page + 1, max));
    }
    const decrementPage = () => {
        if (!conferences) return;
        return setPage(Math.max(0, page - 1));
    }
    const paginate = (conferences: IConference[]) => {
        const start = page * DEFAULT_STEP;
        return conferences.slice(start, start + DEFAULT_STEP);
    }

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

            </div>
            {
                loading
                    ? <div className="feed-board__loader"><TailSpin type="TailSpin" color="#fb8310" /></div>
                    : <ConferenceList conferences={paginate(conferences)} />
            }
            <div className="feed-board__pagination">
                <button onClick={() => decrementPage()}>
                    <FA name="chevron-left" />
                </button>
                <p>{page + 1}</p>
                <button onClick={() => incrementPage()}>
                    <FA name="chevron-right" />
                </button>
            </div>
        </div>
    );
};
