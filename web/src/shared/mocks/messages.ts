import faker from "faker";
import { IMessage } from "../../core/types";

export class MessageMocker {
    private static index: number = 0;

    static single(): IMessage {
        const message: IMessage = {
            id: String(MessageMocker.index),
            text: faker.random.words(3),
            createdAt: faker.date.past(),
            user: {
                id: String(MessageMocker.index),
                login: faker.internet.userName()
            }
        }
        MessageMocker.index += 1;
        return message;
    }

    static many(amount: number): IMessage[] {
        const messages: IMessage[] = []
        for (let i = 0; i < amount; ++i) messages.push(MessageMocker.single());
        return messages;
    }
}
