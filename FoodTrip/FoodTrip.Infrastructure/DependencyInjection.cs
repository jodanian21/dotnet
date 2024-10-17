using FoodTrip.Application.Common.Interfaces.Authentication;
using FoodTrip.Application.Common.Interfaces.Services;
using FoodTrip.Infrastructure.Authentication;
using FoodTrip.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FoodTrip.Application.Common.Interfaces.Persistence;
using FoodTrip.Infrastructure.Persistence;

namespace FoodTrip.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}