import React from "react";
import "./UsersTableRow.sass";
import {IUser} from "../../../../core";
import FA from "react-fontawesome";

type UsersTableRowProps = { user: IUser };

export const UsersTableRow: React.FC<UsersTableRowProps> = ({ user }: UsersTableRowProps) => {
    return (
        <React.Fragment>
            <div className="users-table-row">
                <p className="users-table-col">{user.id}</p>
                <p className="users-table-col">{user.login}</p>
                <p className="users-table-col">{user.email}</p>
                <button className="users-table-col"><FA name="trash"/></button>
                <button className="users-table-col"><FA name="ban"/></button>
            </div>
            <hr />
        </React.Fragment>
    )
}
