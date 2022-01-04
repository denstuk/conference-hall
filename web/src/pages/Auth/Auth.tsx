import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { NetworkBg } from "../../shared/components/NetworkBg/NetworkBg";
import "./Auth.sass";
import { AuthInput } from "./components/AuthInput/AuthInput";
import {AuthAPI} from "../../shared/api";
import {useDispatch} from "react-redux";
import {bindActionCreators} from "redux";
import {LocalStorage} from "../../shared/lib/providers/local-storage";
import { authDispatchers } from "../../shared/store";

export const Auth: React.FC = () => {
    const dispatch = useDispatch();
    const { authorize } = bindActionCreators(authDispatchers, dispatch);
    const navigate = useNavigate();

    const [isSignUp, setIsSignUp] = useState(true);
    const [login, setLogin] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const changeAuthType = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>): void => {
        e.preventDefault();
        return setIsSignUp(!isSignUp);
    };

    const onSubmitButton = async (e: React.MouseEvent<HTMLButtonElement, MouseEvent>): Promise<void> => {
        e.preventDefault();
        try {
            const token = isSignUp ? await AuthAPI.signUp({ login, email, password }) : await AuthAPI.signIn({ email, password });
            LocalStorage.set("AUTH_TOKEN", token);
            const user = await AuthAPI.me();
            authorize(user);
            navigate("/");
        } catch (err) {
            console.log(err);
        }
    };

    return (
        <div className="auth-page">
            <form className="auth-page__form">
                <p className="auth-page__title">
                    Welcome to <br />
                    Conference<span className="auth-page__title-color">Hall</span>
                </p>
                <AuthInput setFunc={setLogin} name="Login" type="text" />
                <AuthInput setFunc={setEmail} name="Email" type="text" />
                <AuthInput setFunc={setPassword} name="Password" type="password" />
                <div className="auth-page__change-type-wrapper">
                    <button className="auth-page__change-type-btn" onClick={(e) => changeAuthType(e)}>
                        {isSignUp ? "Already have account?" : "Not account yet?"}
                    </button>
                </div>
                <button className="auth-page__btn" onClick={(e) => onSubmitButton(e)}>
                    {isSignUp ? "Sign Up" : "Login"}
                </button>
            </form>
            <div className="auth-page__background">
                <NetworkBg />
            </div>
        </div>
    );
};
