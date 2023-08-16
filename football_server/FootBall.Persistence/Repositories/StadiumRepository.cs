using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using FootBallWeb.Persistence.Contexts;

namespace FootBallWeb.Persistence.Repositories
{
    public class StadiumRepository : GenericRepository<Stadium>, IStadiumRepository
    {
        public StadiumRepository(DatabaseContext context) : base(context)
        {

        }
        public object DeleteStadium(int id)
        {
            var checkStadium = context.Stadiums.FirstOrDefault(c => c.Id == id);
            if (checkStadium != null)
            {
                if (checkStadium.Clubs.Count == 0)
                {
                    context.Stadiums.Remove(checkStadium);
                    context.SaveChanges();
                    return new { message = "Delete success" };
                }
                return new { message = "This table has relational data that is linked to another table, so you can't delete it yet!" };
            }
            return new { message = "Not have this stadium" };
        }
    }
}
