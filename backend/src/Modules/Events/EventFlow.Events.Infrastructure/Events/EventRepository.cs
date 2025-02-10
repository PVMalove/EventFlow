using EventFlow.Events.Domain.Events;
using EventFlow.Events.Domain.Events.Entities;
using EventFlow.Events.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Events.Infrastructure.Events;

internal sealed class EventRepository(EventsDbContext context) : IEventRepository
{
    public async Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Events.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }
}
