using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Rg.Web.Api.Attributes;
using Rg.Web.Api.Hubs;
using Rg.Web.Api.Models;
using Rg.Web.Api.Repository;
using Rg.Web.Api.Services;

namespace Rg.Web.Api.Controllers;

[ApiController]
[Route("api/chat")]
[Authorize]
[Consumes("application/json")]
[Produces("application/json")]
public class ChatController : ControllerBase
{
    private readonly IHubContext<ChatHub, IChatHub> _hubContext;

    public ChatController(IHubContext<ChatHub, IChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpGet("list")]
    public async Task<ActionResult<ImmutableList<Chat>>> GetChats([FromServices] IChatService chatService)
    {
        var chats = await chatService.GetChats();
        return chats;
    }
}