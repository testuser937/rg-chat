import Axios, {AxiosPromise} from "axios";
import {SiteUrl} from "@/components/settings/SiteUrl";
import {AuthenticationModel} from "@/models/AuthenticationModel";
import {AuthenticationReadModel} from "@/models/AuthenticationReadModel";
import {UserModel} from "@/models/UserModel";

export class UserController {
    Authenticate(authModel: AuthenticationModel): AxiosPromise<AuthenticationReadModel> {
        return Axios.post(SiteUrl.User_Authenticate(), authModel);
    }

    GetUser(userId: number): AxiosPromise<UserModel>{
        return Axios.get(SiteUrl.User_Get(userId))
    }
}

