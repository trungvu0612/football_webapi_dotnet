using FootBallWeb.Domain.Entities;

namespace FootBallWeb.Domain.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        object DeleteCountry(int id);
    }
}
