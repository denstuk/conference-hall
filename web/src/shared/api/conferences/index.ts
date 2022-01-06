import { HttpClient } from "../http-client";
import { IConference } from "../../../core";
import axios from "axios";
import {CreateConferenceFields} from "./types";

export class ConferencesAPI extends HttpClient {
    static async search(): Promise<IConference[]> {
        try {
            const result = await axios({
                method: "POST",
                url: `${this.server}/api/conferences/search`,
                data: {},
            });
            return result.data;
        } catch (err: any) {
            this.interceptor(err);
        }
    }

    static async create(fields: CreateConferenceFields): Promise<IConference> {
        try {
            const result = await axios({
                method: "POST",
                url: `${this.server}/api/conferences`,
                data: fields,
                headers: {
                    authorization: this.getToken(),
                }
            });
            return result.data;
        } catch (err: any) {
            this.interceptor(err);
        }
    }
}
