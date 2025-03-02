﻿using EventFlow.Common.Application.Caching;
using EventFlow.Common.Application.Clock;
using EventFlow.Common.Application.Data;
using EventFlow.Common.Infrastructure.Caching;
using EventFlow.Common.Infrastructure.Clock;
using EventFlow.Common.Infrastructure.Data;
using EventFlow.Common.Infrastructure.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using StackExchange.Redis;

namespace EventFlow.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
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
        
        return services;
    }
}