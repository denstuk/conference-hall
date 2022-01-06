import dayjs from "dayjs";
import React from "react";
import { Link } from "react-router-dom";
import { IConference } from "../../../../core";
import { cutString } from "../../../lib/string";
import "./ConferenceListItem.sass";
import { useAppSelector } from "../../../store";

type ConferenceListItemProps = {
    conference: IConference;
};

export const ConferenceListItem: React.FC<ConferenceListItemProps> = ({ conference }: ConferenceListItemProps) => {
    const state = useAppSelector((state) => state.authReducer);
    return (
        <div className="conference-list-item">
            <div className="conference-list-item__link">
                <Link to={state.authorized ? `/conferences/${conference.id}` : `/auth`}>{cutString(conference.title, 50)}</Link>
                <p>{dayjs(conference.createdAt).format("HH:mm D-MMM-YYYY")}</p>
            </div>
            <hr />
        </div>
    );
};
