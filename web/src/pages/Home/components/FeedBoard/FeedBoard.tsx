import React, { useEffect, useState } from "react";
import "./FeedBoard.sass";
import { ConferenceList } from "../../../../shared/components/ConferenceList/ConferenceList";
import FA from "react-fontawesome";
import { ConferencesAPI } from "../../../../shared/api";
import { IConference } from "../../../../core";
import TailSpin from "react-loader-spinner";
import { useRequest } from "../../../../shared/hooks";
import {Title} from "../../../../shared/components/Title/Title";

const DEFAULT_STEP = 5;

export const FeedBoard: React.FC = () => {
    const { data, load, loading } = useRequest<IConference[]>(ConferencesAPI.search.bind(ConferencesAPI));
    useEffect(() => {
        load().then();
    }, [load]);

    const [page, setPage] = useState(0);
    const [searchInput, setSearchInput] = useState("");

    const incrementPage = () => {
        if (!data) return;
        const max = Math.floor(data.length / DEFAULT_STEP) + (data.length % DEFAULT_STEP === 0 ? -1 : 0);
        return setPage(Math.min(page + 1, max));
    };
    const decrementPage = () => {
        if (!data) return;
        return setPage(Math.max(0, page - 1));
    };
    const paginate = (conferences: IConference[]) => {
        const start = page * DEFAULT_STEP;
        return conferences.slice(start, start + DEFAULT_STEP);
    };
    const filter = (conferences: IConference[]) => {
        return conferences.filter((c) => c.title.toLowerCase().includes(searchInput.toLowerCase()));
    }

    return (
        <div className="feed-board">
            <div className="feed-board__header">
                <Title text="Last Conferences" />
            </div>
            <div className="feed-board__bar">
                <div className="feed-board__search-bar">
                    <FA name="search" />
                    <input onChange={(e) => setSearchInput(e.target.value)} />
                </div>
            </div>
            {loading ? (
                <div className="feed-board__loader">
                    <TailSpin type="TailSpin" color="#fb8310" />
                </div>
            ) : (
                <ConferenceList conferences={paginate(filter(data!))} />
            )}
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
