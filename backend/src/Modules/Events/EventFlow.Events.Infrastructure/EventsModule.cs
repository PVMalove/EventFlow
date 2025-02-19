﻿using EventFlow.Common.Application.Clock;
using EventFlow.Common.Application.Data;
using EventFlow.Events.Application.Abstractions.Data;
using EventFlow.Events.Domain.Categories;
using EventFlow.Events.Domain.Events;
using EventFlow.Events.Domain.TicketTypes;
using EventFlow.Events.Infrastructure.Categories;
using EventFlow.Events.Infrastructure.DbContexts;
using EventFlow.Events.Infrastructure.Events;
using EventFlow.Events.Infrastructure.TicketTypes;
using EventFlow.Events.Presentation.Categories;
using EventFlow.Events.Presentation.Events;
using EventFlow.Events.Presentation.TicketTypes;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace EventFlow.Events.Infrastructure;

public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        TicketTypeEndpoints.MapEndpoints(app);
        CategoryEndpoints.MapEndpoints(app);
        EventEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddEventsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<EventsDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors());

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}