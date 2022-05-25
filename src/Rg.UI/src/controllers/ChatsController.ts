import Axios, {AxiosPromise} from "axios";
import {SiteUrl} from "@/components/settings/SiteUrl";
import {ChatModel} from "@/models/ChatModel";

export default class ChatsController{
    GetList(): AxiosPromise<ChatModel[]>{
        return Axios.get(SiteUrl.Chat_List())
    }
}

