using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using FootBallWeb.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FootBallWeb.Persistence.Repositories
{
    public class ClubRepository : GenericRepository<Club>, IClubRepository
    {
        public ClubRepository(DatabaseContext context) : base(context)
        {
        }
        public object DeleteClub(int id)
        {
            var checkClub = GetQuery().Include(x => x.Players).FirstOrDefault(x => x.Id == id);
            if (checkClub != null)
            {
                if (checkClub.Players.Count == 0)
                {
                    context.Clubs.Remove(checkClub);
                    context.SaveChanges();
                    return new { message = "Delete success" };
                }
                return new { message = "This table has relational data that is linked to another table, so you can't delete it yet!" };
            }
            return new { message = "Not have this club" };
        }
    }
}
