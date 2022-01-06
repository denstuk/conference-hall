import React from "react";
import "./UsersTable.sass";
import { UsersMocker } from "../../../shared/lib/mocks/users";
import {UsersTableRow} from "./UsersTableRow/UsersTableRow";

export const UsersTable: React.FC = () => {
    const [users] = React.useState(UsersMocker.many(20));
    return (
        <div className="users-table">
            { users.map((u) => <UsersTableRow key={u.id} user={u} />) }
        </div>
    );
};
