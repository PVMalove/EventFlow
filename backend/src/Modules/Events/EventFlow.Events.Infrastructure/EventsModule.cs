using EventFlow.Events.Application;
using EventFlow.Events.Application.Abstractions.Data;
using EventFlow.Events.Domain.Events;
using EventFlow.Events.Infrastructure.Data;
using EventFlow.Events.Infrastructure.DbContexts;
using EventFlow.Events.Infrastructure.Events;
using EventFlow.Events.Presentation.Events;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace EventFlow.Events.Infrastructure;

public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        EventEndpoints.MapEndpoints(app);
    }
    
    public static IServiceCollection AddEventsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);    
        
        services.AddInfrastructure(configuration);
        
        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        
        services.AddDbContext<EventsDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());
        
        return services;
    }
}