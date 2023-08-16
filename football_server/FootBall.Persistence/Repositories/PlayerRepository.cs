using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using FootBallWeb.Persistence.Contexts;

namespace FootBallWeb.Persistence.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DatabaseContext context) : base(context)
        {

        }
        public object DeletePlayer(int id)
        {
            var checkPlayer = context.Player.FirstOrDefault(x => x.Id == id);
            if (checkPlayer != null)
            {
                context.Player.Remove(checkPlayer);
                context.SaveChanges();
                return new { message = "Delete success" };
            }
            return new { message = "Not have this player" };
        }
    }
}
