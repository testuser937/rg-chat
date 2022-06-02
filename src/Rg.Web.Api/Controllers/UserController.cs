using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rg.Web.Api.Models;
using Rg.Web.Api.Repository;
using Rg.Web.Api.Services;

namespace Rg.Web.Api.Controllers;

[ApiController]
[Route("api/user")]
[Consumes("application/json")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    /// <inheritdoc />
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate(AuthRequest model, [FromServices] IUserRepository userRepository)
    {
        var r = await _userService.Authenticate(model);
        if (r == null)
        {
            return Unauthorized("Username or password is incorrect");
        }

        var claims = new List<Claim> {new(ClaimTypes.Name, model.Login) };
        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return Ok(new AuthResponse() {ClanId = r.ClanId, Id = r.Id, Login = r.Login, Token = token});

        var response = await _userService.Authenticate(model);

        if (response == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> GetUser(long id)
    {
        var user = await _userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }
}