import faker from "faker";
import {IConference} from "../../../core";

export class ConferenceMocker {
    private static index: number = 0;

    static single(): IConference {
        const conference = {
            id: String(ConferenceMocker.index),
            title: faker.random.words(10),
            createdAt: faker.date.past(),
            creatorId: "1",
        };
        ConferenceMocker.index += 1;
        return conference;
    }

    static many(amount: number): IConference[] {
        const conferences: IConference[] = [];
        for (let i = 0; i < amount; ++i) conferences.push(ConferenceMocker.single());
        return conferences;
    }
}
