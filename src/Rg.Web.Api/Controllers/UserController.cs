using Microsoft.AspNetCore.Mvc;
using Rg.Web.Api.Attributes;
using Rg.Web.Api.Models;
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
    public async Task<IActionResult> Authenticate(AuthRequest model)
    {
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