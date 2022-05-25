using Rg.Db;

namespace Rg.Web.Api.Settings;

public class AppSettings
{
    public AuthSettings AuthSettings { get; init; }

    public CorsSettings CorsSettings { get; init; }

    public HashSettings HashSettings { get; init; }

    public DbConfiguration DbConfiguration { get; init; }
}