namespace Rg.Web.Api.Settings;

public class AuthSettings
{
    public string Secret { get; init; }

    public int TokenExpireInDays { get; init; }
}