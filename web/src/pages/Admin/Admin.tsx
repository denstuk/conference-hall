import React from "react";
import "./Admin.sass";
import { UsersTable } from "./UsersTable/UsersTable";
import { Title } from "../../shared/components/Title/Title";

export const Admin: React.FC = () => {
    return (
        <div className="admin-page">
            <div className="admin-page__form">
                <Title text="Users" />
                <UsersTable />
            </div>
        </div>
    );
};
