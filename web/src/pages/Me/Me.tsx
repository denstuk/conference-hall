import React, { useEffect } from "react";
import "./Me.sass";
import { ConferenceList } from "../../shared/components/ConferenceList/ConferenceList";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { bindActionCreators } from "redux";
import {authDispatchers, useAppSelector} from "../../shared/store";
import {ConferenceMocker} from "../../shared/lib/mocks/conferences";
import {LocalStorage} from "../../shared/lib/providers/local-storage";
import {StorageKey} from "../../core/constants";

export const Me: React.FC = () => {
    const dispatch = useDispatch();
    const { logout } = bindActionCreators(authDispatchers, dispatch);
    const state = useAppSelector((state) => state.authReducer);
    const navigator = useNavigate();

    useEffect(() => {
        if (!state.authorized) navigator("/");
    });

    const onLogoutClick = () => {
        LocalStorage.remove(StorageKey.AccessToken);
        logout();
    }

    return (
        <div className="me-page">
            <div className="me-page__form">
                <div className="me-page__main">
                    <div className="me-page__photo">
                        <img src={"https://images.unsplash.com/photo-1633332755192-727a05c4013d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=880&q=80"} alt="me" />
                    </div>
                    <div className="me-page__username">
                        <h1>@{state.user?.login}</h1>
                        <h2>{state.user?.email}</h2>
                    </div>
                </div>
                <h1 className="me-page__title">Conferences</h1>
                <div className="me-page__conferences">
                    <ConferenceList conferences={ConferenceMocker.many(5)} />
                </div>
                <h1 className="me-page__title">Settings</h1>
                <div className="me-page__settings">
                    <button>Edit</button>
                    <button onClick={onLogoutClick}>Logout</button>
                </div>
            </div>
        </div>
    );
};
