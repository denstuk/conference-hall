import React, { FC } from "react";

type ConferenceListProps = {
    conferences: { id: number, title: string }[]
}

export const ConferenceList: FC<ConferenceListProps> = ({ conferences }: ConferenceListProps) => {
    return <div className="conference-list">
        {
            conferences.map((conference) => {
                return (<div></div>)
            })
        }
    </div>
}
