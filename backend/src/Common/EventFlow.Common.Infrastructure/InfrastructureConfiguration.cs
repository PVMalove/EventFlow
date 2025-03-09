using EventFlow.Common.Application.Caching;
using EventFlow.Common.Application.Clock;
using EventFlow.Common.Application.Data;
using EventFlow.Common.Application.EventBus;
using EventFlow.Common.Infrastructure.Caching;
using EventFlow.Common.Infrastructure.Clock;
using EventFlow.Common.Infrastructure.Data;
using EventFlow.Common.Infrastructure.Interceptors;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using StackExchange.Redis;

namespace EventFlow.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
        string databaseConnectionString, string radioConnectionString)
    {
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        services.TryAddSingleton<PublishDomainEventsInterceptor>();
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        try
        {
            IConnectionMultiplexer redis = ConnectionMultiplexer.Connect(radioConnectionString);
            services.TryAddSingleton(redis);
            services.AddStackExchangeRedisCache(options =>
                options.ConnectionMultiplexerFactory = () => Task.FromResult(redis));
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }

        services.TryAddSingleton<ICacheService, CacheService>();

        services.TryAddSingleton<IEventBus, EventBus.EventBus>();

        services.AddMassTransit(configure =>
            {
                foreach (Action<IRegistrationConfigurator> configureConsumer in moduleConfigureConsumers)
                {
                    configureConsumer(configure);
                }

                configure.SetKebabCaseEndpointNameFormatter();
                configure.UsingInMemory((context, cfg)
                    => cfg.ConfigureEndpoints(context));
            }
        );

        return services;
    }
}