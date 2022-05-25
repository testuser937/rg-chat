using System.Text.Json.Serialization;

namespace Rg.Web.Api.Models;

public class User
{
    public long Id { get; init; }

    public string Login { get; init; }

    public long? ClanId { get; init; }

    [JsonIgnore]
    public string Password { get; init; }
}