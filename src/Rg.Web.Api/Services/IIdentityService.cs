namespace Rg.Web.Api.Services;

public interface IIdentityService
{
    public Task<long?> UserId { get; }
}