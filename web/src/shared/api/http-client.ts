import { LocalStorage } from "../lib/providers/local-storage";
import { toast } from "react-toastify";
import {StorageKey} from "../../core/constants";

export class HttpClient {
    protected static readonly server: string = "https://localhost:44391";

    protected static getToken(): string {
        const token = LocalStorage.get(StorageKey.AccessToken);
        if (!token) {
            toast("Unauthorized. Missing auth token", {
                type: "error",
            });
        }

        if (!token) throw new Error("Cannot fetch token");
        return `Bearer ${token}`;
    }

    protected static interceptor(error: Error): never {
        toast(error.message, {
            type: "error",
            position: "bottom-right",
            theme: "dark",
        });
        throw error;
    }
}
