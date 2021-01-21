using System.Collections.Generic;
using System.Linq;
using Geometrica.Auth.Models;


namespace Geometrica.Auth.Repository
{
    public class DatabaseRepository: IRepository
    {
        private readonly geometricaContext ctx;

        public DatabaseRepository(geometricaContext ctx)
        {
            this.ctx = ctx;
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
        public IEnumerable<Player> getPlayers()
        {
            return ctx.Players;
        }
    }
}