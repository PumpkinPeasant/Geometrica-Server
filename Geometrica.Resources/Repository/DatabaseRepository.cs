using System.Collections.Generic;
using System.Linq;
using Geometrica.Auth.Resources.Models;
using Geometrica.Resources;
using Geometrica.Resources.Models;

namespace Geometrica.Auth.Resources.Repository
{
    public class DatabaseRepository: IRepository
    {
        private readonly GeometricaContext ctx;

        public DatabaseRepository(GeometricaContext ctx)
        {
            this.ctx = ctx;
        }
        
        public IEnumerable<Country> GetCountries()
        {
            return ctx.Countries;
        }

        public IEnumerable<Gender> GetGenders()
        {
            return ctx.Genders;
        }

        public Player SignUp(Player player)
        {
            player.Uid = ctx.Players.Select(p => p.Uid).Max() + 1;
            ctx.Players.Add(player);
            ctx.SaveChanges();
            return player;
        }

        public Player SignIn(User user)
        {
            return ctx.Players.SingleOrDefault(p => p.Password == user.password && p.Email == user.email);
        }

        public IEnumerable<Game> GetUserGames(int idUser)
        {
            return ctx.Games.Where(g => g.Uid == idUser);
        }

        public IEnumerable<GameWithPlayersNames> GetAllGames()
        {
            return ctx.Games
                .OrderByDescending(game => game.Rightguesses)
                .Select((game) =>
                    new GameWithPlayersNames(game, ctx.Players.Single(p => p.Uid == game.Uid).Nickname));
        }

        public IEnumerable<Player> GetPlayers()
        {
            return ctx.Players;
        }

        public int DeletePlayer(int playerId, User user)
        {
            if (!ctx.Players.Any(p => p.Uid == playerId && p.Email == user.email && p.Password == user.password)) return 0;
            var player = new Player() {Uid = playerId, Email = user.email, Password = user.password};
            ctx.Players.Attach(player);
            var games = ctx.Games.Where(game => game.Uid == playerId);
            ctx.Games.AttachRange(games);
            ctx.Games.RemoveRange(games);
            ctx.Players.Attach(player);
            ctx.Players.Remove(player);
            return ctx.SaveChanges();
        }

        public int UpdatePlayer(Player player)
        {
            ctx.Players.Attach(player);
            ctx.Players.Update(player);
            return ctx.SaveChanges();
        }

        public IEnumerable<string> FindFriends(string playerName)
        {
            return ctx.Players.
                Where(player =>
                    player.Nickname.Contains(playerName) || playerName.Contains(player.Nickname))
                .Select(player => player.Nickname);
        }

        public int DeleteGame(int userId, int gameId, User user)
        {
            if (!ctx.Players.Any(p => p.Uid == userId && p.Email == user.email && p.Password == user.password)) return 0;
            var game = new Game() {Gameid = gameId, Uid = userId};
            ctx.Games.Attach(game);
            ctx.Games.Remove(game);
            return ctx.SaveChanges();
        }

        private bool IsPlayer(Player p, int userId, User user)
        {
            return p.Uid == userId && p.Email == user.email && p.Password == user.password;
        }
    }
}