import React from "react";
import "./Header.sass";
import { HeaderUser } from "./HeaderUser/HeaderUser";
import {HeaderAuth} from "./HeaderAuth/HeaderAuth";
import {HeaderLogo} from "./HeaderLogo/HeaderLogo";
import {useAppSelector} from "../../store";

export const Header: React.FC = () => {
    const state = useAppSelector((state) => state.authReducer);
    return (
        <header className="page-header">
            <div className="page-header__logo"><HeaderLogo /></div>
            <div className="page-header__user">{state.authorized ? <HeaderUser /> : <HeaderAuth />}</div>
        </header>
    );
};
