namespace Rg.Web.Api.Models;

public class MessageWriteDto
{
    public long ChatId { get; init; }

    public long UserId { get; init; }

    public string Text { get; init; }

    public DateTimeOffset Dt { get; init; }
}