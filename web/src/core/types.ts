export interface IConference {
    id: string;
    title: string;
    createdAt: Date;
}

export interface IMessage {
    id: string;
    text: string;
    createdAt: Date;
    user: IUser;
}

export interface IUser {
    id: string;
    login: string;
}
