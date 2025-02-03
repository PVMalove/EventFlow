using EventFlow.Events.Presentation.Events.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Events.Presentation.DbContexts;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options)
{
    internal DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}
