using System.Collections.Generic;
using System.Linq;
using Geometrica.Auth.Models;


namespace Geometrica.Auth.Repository
{
    public class DatabaseRepository: IRepository
    {
        private readonly GeometricaContext ctx;

        public DatabaseRepository(GeometricaContext ctx)
        {
            this.ctx = ctx;
        }
        
        public Player SignUp(Player player)
        {
            if (IsNotUniqueEmail(player.Email)) return null;
            player.Uid = ctx.Players.Select(p => p.Uid).Max() + 1;
            ctx.Players.Add(player);
            ctx.SaveChanges();
            return player;
        }

        private bool IsNotUniqueEmail(string email)
        {
            return ctx.Players.Any(player => player.Email == email);
        }

        public Player SignIn(User user)
        {
            return ctx.Players.SingleOrDefault(p => p.Password == user.password && p.Email == user.email);
        }
        public IEnumerable<Player> GetPlayers()
        {
            return ctx.Players;
        }
    }
}