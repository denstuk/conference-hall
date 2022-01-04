import {AuthActionType} from "./types";
import type {IUser} from "../../../core";
import type {AuthAction} from "./actions";

type AuthData = { authorized: boolean; user?: IUser };
const InitialData: AuthData = { authorized: false };

export const authReducer = (state: AuthData = InitialData, action: AuthAction): AuthData => {
    switch (action.type) {
        case AuthActionType.Authorize:
            return { ...state, authorized: true, user: action.user };
        case AuthActionType.Logout:
            return { ...state, authorized: false, user: undefined };
        default:
            return state;
    }
};
