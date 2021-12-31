import React, { FC } from "react";
import { IConference } from "../../../../core/conferences/types";
import "./ConferenceListItem.sass";

type ConferenceListItemProps = {
    conference: IConference;
};

export const ConferenceListItem: FC<ConferenceListItemProps> = ({ conference }: ConferenceListItemProps) => {
    return (
        <div className="conference-list-item">
            <div className="conference-list-item__link">
                <a href="#1">{conference.title}</a>
                <p>{conference.createdAt.toISOString()}</p>
            </div>
            <hr />
        </div>
    );
};
