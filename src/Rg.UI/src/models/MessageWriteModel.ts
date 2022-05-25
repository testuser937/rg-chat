export class MessageWriteModel {
    ChatId: number;
    UserId: number;
    Text: string;
    Dt: Date;


    constructor(chatId: number, userId: number, text: string, dt: Date) {
        this.ChatId = chatId;
        this.UserId = userId;
        this.Text = text;
        this.Dt = dt;
    }
}