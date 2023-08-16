using FootBallWeb.Domain.Interfaces;
using FootBallWeb.Persistence.Contexts;

namespace FootBallWeb.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext context;
        public UnitOfWork(DatabaseContext context)
        {
            this.context = context;
            Club = new ClubRepository(this.context);
            Country = new CountryRepository(this.context);
            Player = new PlayerRepository(this.context);
            Stadium = new StadiumRepository(this.context);
        }

        public IClubRepository Club { get; private set; }
        public IPlayerRepository Player { get; private set; }
        public IStadiumRepository Stadium { get; private set; }
        public ICountryRepository Country { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
