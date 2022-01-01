import React, { useState } from "react";
import { InputField } from "../../shared/components/InputField/InputField";

export const Auth: React.FC = () => {
    const [login, setLogin] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    return <div className="auth-page">
        <form className="auth-page__form">
            <InputField setFunc={setLogin} name="Login" type="text" />
            <InputField setFunc={setEmail} name="Email" type="text" />
            <InputField setFunc={setPassword} name="Password" type="password" />
            <button>Регистрация</button>
        </form>
    </div>;
}
