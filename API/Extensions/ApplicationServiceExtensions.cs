using API.Helpers;
using API.Repositories;
using API.RepositoryContracts;
using API.ServiceContracts;
using API.Services;
using API.UoW;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAutoMapper(typeof(Startup));
        services.AddAutoMapper(typeof(AutoMapperProfiles));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUsersService, UsersService>();

        services.AddScoped<ICardsRepository, CardsRepository>();
        services.AddScoped<ICardsService, CardsService>();

        services.AddScoped<ILogsRepository, LogsRepository>();
        services.AddScoped<ILogsService, LogsService>();

        services.AddScoped<IListItemsRepository, ListItemsRepository>();
        services.AddScoped<IListItemsService, ListItemsService>();

        return services;
    }
}
