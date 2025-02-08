using EventFlow.Events.Application.Abstractions.Data;
using EventFlow.Events.Domain.Categories;
using EventFlow.Events.Domain.Events.Entities;
using EventFlow.Events.Domain.TicketTypes;
using EventFlow.Events.Infrastructure.Events;
using EventFlow.Events.Infrastructure.TicketTypes;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Events.Infrastructure.DbContexts;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }

    internal DbSet<Category> Categories { get; set; }

    internal DbSet<TicketType> TicketTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);

        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new TicketTypeConfiguration());
    }
}
