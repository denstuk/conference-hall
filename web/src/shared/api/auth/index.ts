import { SignInData, SignUpData } from "./types";
import { HttpClient } from "../http-client";
import axios from "axios";
import {IUser} from "../../../core";

export class AuthAPI extends HttpClient {
    static async signIn(data: SignInData): Promise<string> {
        try {
            const result = await axios({
                method: "POST",
                url: `${this.server}/api/auth/sign-in`,
                data
            });
            return result.data.accessToken;
        } catch (err: any) {
            this.interceptor(err);
        }
    }

    static async signUp(data: SignUpData): Promise<string> {
        try {
            const result = await axios({
                method: "POST",
                url: `${this.server}/api/auth/sign-up`,
                data
            });
            return result.data.accessToken;
        } catch (err: any) {
            this.interceptor(err);
        }
    }

    static async me(): Promise<IUser> {
        try {
            const result = await axios({
                method: "GET",
                url: `${this.server}/api/auth/me`,
                headers: { authorization: this.getToken() }
            });
            return result.data;
        } catch (err: any) {
            this.interceptor(err);
        }
    }
}
