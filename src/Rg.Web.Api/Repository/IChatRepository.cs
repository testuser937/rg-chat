using System.Collections.Immutable;
using Rg.Web.Api.Models;

namespace Rg.Web.Api.Repository;

public interface IChatRepository
{
    public Task<ImmutableList<Chat>> GetChats();
}