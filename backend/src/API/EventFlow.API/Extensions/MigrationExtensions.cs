﻿using EventFlow.Events.Infrastructure.DbContexts;
using EventFlow.Ticketing.Infrastructure.Database;
using EventFlow.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.API.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<EventsDbContext>(scope);
        ApplyMigration<UsersDbContext>(scope);
        ApplyMigration<TicketingDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
        Console.WriteLine($"Applying migrations for {typeof(TDbContext).Name}");
        context.Database.Migrate();
    }
}
