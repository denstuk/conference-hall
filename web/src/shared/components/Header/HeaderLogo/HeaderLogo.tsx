import React from "react";
import "./HeaderLogo.sass";
import { Link } from "react-router-dom";

export const HeaderLogo: React.FC = () => {
    return (
        <Link to="/" className="header-logo">
            Conference<span className="header-logo__color">Hall</span>
        </Link>
    );
};
