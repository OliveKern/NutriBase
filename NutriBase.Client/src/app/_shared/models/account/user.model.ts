export interface User {
    id?: number;
    username: string;
    firstname: string;
    lastname: string;
    password?: string;
    email: string,
    token?: string;
}