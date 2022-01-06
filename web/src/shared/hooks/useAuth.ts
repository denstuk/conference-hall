import { useDispatch } from "react-redux";
import { bindActionCreators } from "redux";
import { authDispatchers } from "../store/auth";
import { LocalStorage } from "../lib/providers/local-storage";
import { StorageKey } from "../../core/constants";
import { AuthAPI } from "../api";
import { Toaster } from "../lib/providers/toaster";
import {useState} from "react";
import {IUser} from "../../core";

export const useAuth = () => {
    const [user, setUser] = useState<IUser>();
    const dispatch = useDispatch();
    const { authorize, logout } = bindActionCreators(authDispatchers, dispatch);

    const auth = async function checkAuthorization(): Promise<void> {
        const token = LocalStorage.get(StorageKey.AccessToken);
        if (!token) {
            logout();
            return;
        }
        try {
            const user = await AuthAPI.me();
            if (user) {
                setUser(user);
                authorize(user);
                return;
            }
        } catch (err: any) {
            Toaster.error(err.message);
        }
        logout();
    };

    return { auth, user };
};
