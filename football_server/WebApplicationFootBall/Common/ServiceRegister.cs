using FootBallWeb.Domain.Interfaces;
using FootBallWeb.Persistence.Repositories;
using WebAPI.Application.IService;
using WebAPI.Application.Service;
using WebApplicationFootBall.Business.IService;
using WebApplicationFootBall.Business.Service;

namespace WebApplicationFootBall.Common
{
    public static class ServiceRegister
    {
        public static IServiceCollection ServiceRegisterComon(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IStadiumService, StadiumService>();
            services.AddTransient<IClubService, ClubService>();
            services.AddTransient<IPlayerService, PlayerService>();
            return services;
        }
    }

}
