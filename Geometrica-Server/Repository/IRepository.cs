using System.Collections;
using System.Collections.Generic;
using Geometrica_Server.Models;

namespace Geometrica_Server.Repository
{
    public interface IRepository
    {
        IEnumerable<Country> GetCountry();
        IEnumerable<Gender> GetGenders();
        Player SignUp(Player player);
        Player SignIn(User user);
        IEnumerable<Game> GetUserGames(int idUser);
        IEnumerable<Game> GetAllGames();
        IEnumerable<Player> getPlayers();
    }
}