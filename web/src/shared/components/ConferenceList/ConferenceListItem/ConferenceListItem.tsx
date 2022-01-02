import dayjs from "dayjs";
import React from "react";
import { Link } from "react-router-dom";
import { IConference } from "../../../../core/types";
import { cutString } from "../../../libs/string";
import "./ConferenceListItem.sass";

type ConferenceListItemProps = {
    conference: IConference;
};

export const ConferenceListItem: React.FC<ConferenceListItemProps> = ({ conference }: ConferenceListItemProps) => {
    return (
        <div className="conference-list-item">
            <div className="conference-list-item__link">
                <Link to={`/conferences/${conference.id}`}>{cutString(conference.title, 50)}</Link>
                <p>{dayjs(conference.createdAt).format("HH:mm D-MMM-YYYY")}</p>
            </div>
            <hr />
        </div>
    );
};
