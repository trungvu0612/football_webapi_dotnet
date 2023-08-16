using FootBallWeb.Domain.Entities;

namespace FootBallWeb.Domain.Interfaces
{
    public interface IClubRepository : IGenericRepository<Club>
    {
        object DeleteClub(int id);
    }
}
