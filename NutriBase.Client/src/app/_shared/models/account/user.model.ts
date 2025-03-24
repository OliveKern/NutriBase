export interface UserDto {
    id?: number;
    username: string;
    firstname: string;
    lastname: string;
    password?: string;
    email: string,
    token?: string;
}

export class InputDto {
    password: string = '';
    email: string = '';
}

export class RegisterDto {
    username: string;
    firstname: string;
    lastname: string;
    password: string;
    email: string;

    constructor() {
        this.username = '';
        this.firstname = '';
        this.lastname = '';
        this.password = '';
        this.email = '';
    }
}

