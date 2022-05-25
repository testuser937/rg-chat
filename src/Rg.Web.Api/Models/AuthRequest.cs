using System.ComponentModel.DataAnnotations;

namespace Rg.Web.Api.Models;

public class AuthRequest
{
    [Required]
    public string Login { get; init; }

    [Required]
    public string Password { get; init; }
}