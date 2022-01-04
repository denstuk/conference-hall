import React from "react";
import "./HeaderUser.sass";
import FA from "react-fontawesome";
import { Link } from "react-router-dom";

export const HeaderUser: React.FC = () => {
    return (
        <Link className="header-user" to="/me">
            <div className="header-user__img">
                <FA className="page-header__user-img" name="user-circle" />
            </div>
        </Link>
    );
};
