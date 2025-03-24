using Microsoft.Extensions.DependencyInjection;
using SharedKernel.CQRS.Command;
using SharedKernel.CQRS.Query;
using MediatR;
using System.Reflection;
using MassTransit;
using SharedKernel.Event;
using Microsoft.Extensions.Configuration;
using SharedKernel.Behaviors;

namespace SharedKernel;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSharedKernel(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqHost = configuration.GetSection("RabbitMQ:Host").Value;
        var redisConfig = configuration.GetSection("Redis:ConnectionString").Value;

        //CQRS
        services.AddScoped<ICommandBus, CommandBus>();
        services.AddScoped<IQueryBus, QueryBus>();

        //Mediatr
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        //mass transit
        services.AddMassTransit(config =>
        {
            config.AddConsumers(Assembly.GetExecutingAssembly());

            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("rabbittest");

                cfg.ConfigureEndpoints(ctx);
            });
        });

        //redis
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "redistest";
        });


        services.AddScoped<IEventBus, EventBus>();

        return services;
    }
}
