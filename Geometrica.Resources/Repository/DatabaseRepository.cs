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

        public IEnumerable<Game> GetAllGames()
        {
            return ctx.Games;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return ctx.Players;
        }
    }
}