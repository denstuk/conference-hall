import faker from "faker";
import { IConference } from "../../core/types";

export class ConferenceMocker {
    private static index: number = 0;

    static single(): IConference {
        const conference = {
            id: String(ConferenceMocker.index), 
            title: faker.random.words(10), 
            createdAt: faker.date.past()
        }
        ConferenceMocker.index += 1;
        return conference;
    }

    static many(amount: number): IConference[] {
        const conferences: IConference[] = [];
        for (let i = 0; i < amount; ++i) conferences.push(ConferenceMocker.single());
        return conferences;
    }
}

