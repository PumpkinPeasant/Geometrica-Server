using System.Collections.Generic;
using Geometrica.Auth.Models;

namespace Geometrica.Auth.Repository
{
    public interface IRepository
    {
        Player SignUp(Player player);
        Player SignIn(User user);
        IEnumerable<Player> getPlayers();
    }
}