using EventFlow.Events.Application.Abstractions.Data;
using EventFlow.Events.Domain.Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Events.Infrastructure.DbContexts;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}