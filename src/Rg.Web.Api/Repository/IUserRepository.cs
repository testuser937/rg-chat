using System.Collections.Immutable;
using Rg.Web.Api.Models;

namespace Rg.Web.Api.Repository;

public interface IUserRepository
{
    Task<ImmutableList<User>> GetUsers();
}