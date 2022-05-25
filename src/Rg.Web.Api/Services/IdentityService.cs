using Rg.Web.Api.Models;
using Rg.Web.Api.Repository;

namespace Rg.Web.Api.Services;

public class IdentityService : IIdentityService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;

    public IdentityService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
    }

    /// <inheritdoc />
    public Task<long?> UserId => GetUserId();

    private async Task<long?> GetUserId()
    {
        var userLogin = GetUserLogin();
        var users = await _userRepository.GetUsers();
        return users.FirstOrDefault(x => x.Login == userLogin).Id;
    }

    private string GetUserLogin()
    {
        var user = _httpContextAccessor.HttpContext.Items["User"] as User;
        var userLogin = user?.Login;
        if (!string.IsNullOrWhiteSpace(userLogin))
        {
            return userLogin;
        }

        throw new Exception("Пользователь не авторизован");
    }
}