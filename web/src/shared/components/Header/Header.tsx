import React from "react";
import "./Header.sass";
import { Link } from "react-router-dom";
import { HeaderUser } from "./HeaderUser/HeaderUser";

export const Header: React.FC = () => {
    const isAuthorized = true;

    return (
        <header className="page-header">
            <div className="page-header__logo">
                <Link to="/">Conference<span className="page-header__color-wrapper">Hall</span></Link>
            </div>
            <div className="page-header__user">
                { isAuthorized ? <HeaderUser /> : <div><button>Регистрация</button></div> }
            </div>
        </header>
    );
};
