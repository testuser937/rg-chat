import {SiteSettings} from "@/components/settings/SiteSettings";

export class SiteUrl {

    static User_Authenticate(): string {
        return SiteSettings.baseUrl() + "api/user/authenticate";
    }

    static User_Get(userId: number){
        return SiteSettings.baseUrl() + `api/user/${userId}`;
    }

    static Chat_List(): string {
        return SiteSettings.baseUrl() + "api/chat/list";
    }

    static Message_GetLastMessages(chatId: number, count: number): string {
        return SiteSettings.baseUrl() + `api/message?chatId=${chatId}&count=${count}`;
    }

    static Message_SendMessage(): string{
        return SiteSettings.baseUrl() + `api/message`
    }
}