export interface IConference {
    id: string;
    title: string;
    creatorId: string;
    creator?: IUser;
    createdAt: Date;
}

export interface IMessage {
    id: string;
    text: string;
    createdAt: Date;
    creator: IUser;
}

export interface IUser {
    id: string;
    role: number;
    login: string;
    email: string;
    blockedUntil?: Date;
    conferences?: IConference[];
    createdConferences?: IConference[];
    createdAt: Date;
}

export interface IToken {
    accessToken: string;
}
