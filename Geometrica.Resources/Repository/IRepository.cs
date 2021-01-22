using System.Collections;
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
        IEnumerable<GameWithPlayersNames> GetAllGames();
        IEnumerable<Player> GetPlayers();
        int DeletePlayer(int playerId, User user);
        int UpdatePlayer(Player player);
        IEnumerable<string> FindFriends(string playerName);
        int DeleteGame(int userId, int gameId, User user);
    }
}