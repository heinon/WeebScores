using AnimeService.Infrastructure.Persistence;
using AnimeService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeService.Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AnimeServiceDatabase");

        services.AddDbContext<AnimeServiceDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IAnimeRepository, AnimeRepository>();

        return services;
    }
}
