import React from "react";
import "./Me.sass";
import {ConferenceList} from "../../shared/components/ConferenceList/ConferenceList";
import {ConferenceMocker} from "../../shared/mocks/conferences";

const tempPath = "https://images.unsplash.com/photo-1633332755192-727a05c4013d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=880&q=80"

export const Me: React.FC = () => {
    return <div className="me-page">
        <div className="me-page__form">
            <div className="me-page__main">
                <div className="me-page__photo">
                    <img src={tempPath} alt="me" />
                </div>
                <div className="me-page__username">
                    <h1>Denis Stuk</h1>
                    <h2>@denstuk</h2>
                </div>
            </div>
            <h1>Conferences</h1>
            <div className="me-page__conferences">
                <ConferenceList conferences={ConferenceMocker.many(5)} />
            </div>
        </div>
    </div>;
}
