import {HttpClient} from "../http-client";
import {IConference} from "../../../core";
import axios from "axios";

export class ConferencesAPI extends HttpClient {
    static async search(): Promise<IConference[]> {
        try {
            const result = await axios({
                method: "POST",
                url: `${this.server}/api/conferences/search`,
                data: {}
            });
            return result.data;
        } catch (err: any) {
            this.interceptor(err);
        }
    }
}
