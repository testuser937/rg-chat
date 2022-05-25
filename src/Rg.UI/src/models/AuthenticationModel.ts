export class AuthenticationModel {
    Login: string;
    Password: string;


    constructor(Login: string, Password: string) {
        this.Login = Login;
        this.Password = Password;
    }
}