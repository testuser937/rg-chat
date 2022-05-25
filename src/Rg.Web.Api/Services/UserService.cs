using Rg.Web.Api.Models;
using Rg.Web.Api.Repository;

namespace Rg.Web.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly IHashService _hashService;

    public UserService(ITokenService tokenService, IHashService hashService, IUserRepository userRepository)
    {
        _tokenService = tokenService;
        _hashService = hashService;
        _userRepository = userRepository;
    }

    /// <inheritdoc />
    public async Task<AuthResponse?> Authenticate(AuthRequest model)
    {
        var users = await _userRepository.GetUsers();
        var user = users
            .FirstOrDefault(x => x.Login == model.Login && x.Password == _hashService.GetHash(model.Password));
        if (user == null)
        {
            return null;
        }

        var token = _tokenService.GenerateToken(user);
        return new AuthResponse
        {
            Id = user.Id,
            Login = user.Login,
            Token = token,
            ClanId = user.ClanId,
        };
    }

    /// <inheritdoc />
    public async Task<User?> GetById(long id)
    {
        var users = await _userRepository.GetUsers();
        return users.FirstOrDefault(x => x.Id == id);
    }
}