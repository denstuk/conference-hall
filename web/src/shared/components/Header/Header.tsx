import React from "react";
import "./Header.sass";
import { Link, useNavigate } from "react-router-dom";
import { HeaderUser } from "./HeaderUser/HeaderUser";
import {useAppSelector} from "../../store";


export const Header: React.FC = () => {
    const state = useAppSelector((state) => state.authReducer);
    const navigator = useNavigate();

    return (
        <header className="page-header">
            <div className="page-header__logo">
                <Link to="/">
                    Conference<span className="page-header__color-wrapper">Hall</span>
                </Link>
            </div>
            <div className="page-header__user">
                {state.authorized ? <HeaderUser /> : <button onClick={() => navigator("/auth")}>Authentication</button>}
            </div>
        </header>
    );
};
