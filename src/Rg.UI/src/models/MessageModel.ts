export default class MessageModel{
    Id: number;
    ChatId: number;
    UserId: number;
    Text: string;
    Dt: Date;


    constructor(Id: number, ChatId: number, UserId: number, Text: string, Dt: Date) {
        this.Id = Id;
        this.ChatId = ChatId;
        this.UserId = UserId;
        this.Text = Text;
        this.Dt = Dt;
    }
}