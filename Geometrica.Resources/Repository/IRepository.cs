using System.Collections;
using System.Collections.Generic;
using Geometrica.Resources.Models;

namespace Geometrica.Resources.Repository
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