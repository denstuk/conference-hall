import React from "react";
import "./HeaderAuth.sass";
import {useNavigate} from "react-router-dom";

export const HeaderAuth: React.FC = () => {
    const navigate = useNavigate();

    return <div className="header-auth">
        <button onClick={() => navigate("/auth?sign-in")}>Sign In</button>
        <button onClick={() => navigate("/auth?sign-up")}>Sign Up</button>
    </div>
}
