import { IUser } from "../../../core";
import faker from "faker";

export class UsersMocker {
    private static index: number = 0;

    static single(): IUser {
        const user: IUser = {
            id: "mockedUser#" + UsersMocker.index,
            login: faker.internet.userName(),
            email: faker.internet.email(),
            createdAt: new Date(),
            role: 1,
        };
        UsersMocker.index += 1;
        return user;
    }

    static many(amount: number): IUser[] {
        const users: IUser[] = [];
        for (let i = 0; i < amount; i++) users.push(UsersMocker.single());
        return users;
    }
}
