import React from "react";
import { IConference } from "../../../core/types";
import { ConferenceListItem } from "./ConferenceListItem/ConferenceListItem";

type ConferenceListProps = {
    conferences: IConference[];
};

export const ConferenceList: React.FC<ConferenceListProps> = ({ conferences }: ConferenceListProps) => {
    return (
        <div className="conference-list">
            {conferences.map((c) => <ConferenceListItem key={c.id} conference={c} />)}
        </div>
    );
};
