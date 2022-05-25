namespace Rg.Web.Api.Models;

public class AuthResponse
{
    public long Id { get; init; }

    public string Login { get; init; }

    public string Token { get; init; }

    public long? ClanId { get; init; }
}