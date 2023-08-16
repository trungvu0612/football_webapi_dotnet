using FootBallWeb.Domain.Entities;
using FootBallWeb.Domain.Interfaces;
using FootBallWeb.Persistence.Contexts;

namespace FootBallWeb.Persistence.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DatabaseContext context) : base(context)
        {

        }
        public object DeleteCountry(int id)
        {
            var checkCountry = context.Countries.FirstOrDefault(c => c.Id == id);
            if (checkCountry != null)
            {
                if (checkCountry.Stadiums.Count == 0 && checkCountry.Players.Count == 0)
                {
                    context.Countries.Remove(checkCountry);
                    context.SaveChanges();
                    return new { message = "Delete success" };
                }
                return new { message = "This table has relational data that is linked to another table, so you can't delete it yet!" };
            }
            return new { message = "Not have this club" };
        }
    }
}
