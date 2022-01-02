import React from "react";
import "./InputField.sass";

type InputFieldProps = {
    setFunc: Function
    name: string;
    type: string;
}

export const InputField: React.FC<InputFieldProps> = ({ setFunc, name, type }: InputFieldProps) => {
    return <div className="input-field">
        <p className="input-field__name">{name}</p>
        <input className="input-field__input" onChange={(e) => setFunc(e.target.value)} type={type} />
    </div>;
}
