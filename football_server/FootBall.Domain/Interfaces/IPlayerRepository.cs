using FootBallWeb.Domain.Entities;

namespace FootBallWeb.Domain.Interfaces
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        object DeletePlayer(int id);
    }
}
