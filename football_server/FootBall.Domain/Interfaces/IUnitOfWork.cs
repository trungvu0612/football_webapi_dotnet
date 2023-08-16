namespace FootBallWeb.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClubRepository Club { get; }

        IStadiumRepository Stadium { get; }

        IPlayerRepository Player { get; }

        ICountryRepository Country { get; }

        int Save();
    }
}
