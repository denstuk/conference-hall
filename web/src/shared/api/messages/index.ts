import {HttpClient} from "../http-client";
import {IMessage} from "../../../core";
import axios from "axios";
import type { MessagesSearchFields } from "../conferences/types";

export class MessagesAPI extends HttpClient {
    static async search(searchFields?: MessagesSearchFields): Promise<IMessage[]> {
        try {
            const result = await axios({
                method: "POST",
                url: `${this.server}/api/messages/search`,
                data: searchFields || {}
            });
            return result.data;
        } catch (err: any) {
            this.interceptor(err);
        }
    }
}
