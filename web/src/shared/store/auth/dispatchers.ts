import { Dispatch } from "redux";
import { AuthActionType } from "./types";
import type { IUser } from "../../../core";
import { AuthAction } from "./actions";

export const authorize = (user: IUser) => {
    return (dispatch: Dispatch<AuthAction>) => dispatch({ type: AuthActionType.Authorize, user });
};

export const logout = () => {
    return (dispatch: Dispatch<AuthAction>) => dispatch({ type: AuthActionType.Logout });
};
