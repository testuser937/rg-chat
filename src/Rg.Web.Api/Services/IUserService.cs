using Rg.Web.Api.Models;

namespace Rg.Web.Api.Services;

public interface IUserService
{
    Task<AuthResponse?> Authenticate(AuthRequest model);

    Task<User?> GetById(long id);
}