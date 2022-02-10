import { ILogin } from "./login";

export interface IRegister extends ILogin {
    name: string;
    lastname: string;
}
