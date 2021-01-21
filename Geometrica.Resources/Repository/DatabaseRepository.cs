using System.Collections.Generic;
using System.Linq;
using Geometrica.Resources.Models;

namespace Geometrica.Resources.Repository
{
    public class DatabaseRepository: IRepository
    {
        private readonly geometricaContext ctx;

        public DatabaseRepository(geometricaContext ctx)
        {
            this.ctx = ctx;
        }
        
        public IEnumerable<Country> GetCountry()
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

        public IEnumerable<Player> getPlayers()
        {
            return ctx.Players;
        }
    }
}