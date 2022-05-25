import axios, {AxiosPromise} from "axios";
import {SiteUrl} from "@/components/settings/SiteUrl";
import MessageModel from "@/models/MessageModel";
import {MessageWriteModel} from "@/models/MessageWriteModel";

export default class MessageController{
    GetLastMessages(chatId: number, count: number = 10): AxiosPromise<MessageModel[]>{
        return axios.get(SiteUrl.Message_GetLastMessages(chatId, count));
    }

    SendMessage(message: MessageWriteModel) : AxiosPromise<number>{
        return axios.post(SiteUrl.Message_SendMessage(), message);
    }
}

