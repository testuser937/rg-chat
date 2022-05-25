namespace Rg.Web.Api.Models;

public class Message
{
    public long Id { get;  }

    public long ChatId { get;  }

    public long UserId { get;  }

    public string Text { get; }

    public DateTimeOffset Dt { get; }

    public Message(long id, long chatId, long userId, string text, DateTimeOffset dt)
    {
        Id = id;
        ChatId = chatId;
        UserId = userId;
        Text = text;
        Dt = dt;
    }

    private Message()
    {
    }
}