using FootBallWeb.Domain.Entities;

namespace FootBallWeb.Domain.Interfaces
{
    public interface IStadiumRepository : IGenericRepository<Stadium>
    {
        object DeleteStadium(int id);
    }
}
