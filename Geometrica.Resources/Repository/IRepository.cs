using System.Collections.Generic;
using Geometrica.Auth.Resources.Models;
using Geometrica.Resources;
using Geometrica.Resources.Models;

namespace Geometrica.Auth.Resources.Repository
{
    public interface IRepository
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<Gender> GetGenders();
        Player SignUp(Player player);
        Player SignIn(User user);
        IEnumerable<Game> GetUserGames(int idUser);
        IEnumerable<Game> GetAllGames();
        IEnumerable<Player> GetPlayers();
    }
}