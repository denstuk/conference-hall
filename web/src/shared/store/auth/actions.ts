import type {IUser} from "../../../core";
import type { AuthActionType } from "./types";

interface AuthorizeAction {
    type: AuthActionType.Authorize;
    user: IUser;
}

interface LogoutAction {
    type: AuthActionType.Logout;
}

export type AuthAction = AuthorizeAction | LogoutAction;