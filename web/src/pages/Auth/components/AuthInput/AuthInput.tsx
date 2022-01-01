import React from "react";
import "./AuthInput.sass";

type AuthInputProps = {
    setFunc: Function
    name: string;
    type: string;
}

export const AuthInput: React.FC<AuthInputProps> = ({ setFunc, name, type }: AuthInputProps) => {
    return <div className="auth-input">
        <p className="auth-input__name">{name}</p>
        <input className="auth-input__input" onChange={(e) => setFunc(e.target.value)} type={type} />
    </div>;
}
