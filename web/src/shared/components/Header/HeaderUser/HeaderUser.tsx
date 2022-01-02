import React from "react";
import "./HeaderUser.sass"
import FA from "react-fontawesome";
import { Link } from "react-router-dom";

export const HeaderUser: React.FC = () => {
    return <Link className="header-user" to="/me">
        <div className="header-user__username">
            <p className="header-user__name">Denis Stuk</p>
            <p className="header-user__login">@denstuk</p>
        </div>
        <div className="header-user__img">
            <FA className="page-header__user-img" name="user-circle" />
        </div>
    </Link>;
}
