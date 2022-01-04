import {toast} from "react-toastify";

export class Toaster {
    static error(message: string): void {
        toast(message, {
            type: "error",
            position: "bottom-right",
            theme: "dark",
        });
    }

    static info(message: string): void {
        toast(message, {
            type: "info",
            position: "bottom-right",
            theme: "dark"
        })
    }
}
