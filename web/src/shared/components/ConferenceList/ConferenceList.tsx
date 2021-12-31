import React, { FC } from "react";
import { IConference } from "../../../core/conferences/types";
import { ConferenceListItem } from "./ConferenceListItem/ConferenceListItem";

type ConferenceListProps = {
    conferences: IConference[];
};

export const ConferenceList: FC<ConferenceListProps> = ({ conferences }: ConferenceListProps) => {
    return (
        <div className="conference-list">
            {conferences.map((conference) => (
                <ConferenceListItem key={conference.id} conference={conference} />
            ))}
        </div>
    );
};
