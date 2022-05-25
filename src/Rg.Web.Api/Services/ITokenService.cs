using Rg.Web.Api.Models;

namespace Rg.Web.Api.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}