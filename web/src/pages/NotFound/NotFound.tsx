import React from "react";
import { Link } from "react-router-dom";
import {NetworkBg} from "../../shared/components/NetworkBg/NetworkBg";
import "./NotFound.sass";

export const NotFound: React.FC = () => {
    return (
        <div className="notfound-page">
            <NetworkBg />
            <div className="notfound-page__form">
                <h1>Page Not Found</h1>
                <Link className="notfound-page__link" to="/">Back To Home</Link>
            </div>
        </div>
    );
}