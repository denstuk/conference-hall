import React, {FC} from "react";
import "./Header.sass";
import FA from "react-fontawesome";

export const Header: FC = () => {
    const isAuthorized = true;

    return <header className="page-header">
        <div className="page-header__logo">
            Conference<span className="page-header__color-wrapper">Hall</span>
        </div>
        <div className="page-header__user">
            {
                isAuthorized ? <div className="page-header__user-info">
                    <div>@denstuk</div>
                    <FA className="page-header__user-img" name="user-circle" />
                </div> : <div>
                    <button>Регистрация</button>
                </div>
            }
        </div>
    </header>
}