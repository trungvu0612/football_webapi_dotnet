using FootBallWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootBallWeb.Persistence.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
    }

}
