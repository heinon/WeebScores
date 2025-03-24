using AnimeService.Application.AnimeApplication.Command.AddAnime;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeService.Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


        return services;
    }
}
