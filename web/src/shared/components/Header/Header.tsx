import React from "react";
import "./Header.sass";
import FA from "react-fontawesome";
import { Link } from "react-router-dom";

export const Header: React.FC = () => {
    const isAuthorized = true;

    return (
        <header className="page-header">
            <div className="page-header__logo">
                <Link to="/">
                    Conference<span className="page-header__color-wrapper">Hall</span>
                </Link>
            </div>
            <div className="page-header__user">
                {isAuthorized ? (
                    <div className="page-header__user-info">
                        <div className="self-board__user">
                            <p className="self-board__username">Denis Stuk</p>
                            <p className="self-board__tag">@denstuk</p>
                        </div>
                        <div className="self-board__photo">
                            <FA className="page-header__user-img" name="user-circle" />
                        </div>
                    </div>
                ) : (
                    <div>
                        <button>Регистрация</button>
                    </div>
                )}
            </div>
        </header>
    );
};
