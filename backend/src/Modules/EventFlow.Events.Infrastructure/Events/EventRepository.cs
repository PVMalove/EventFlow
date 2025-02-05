using EventFlow.Events.Domain.Events;
using EventFlow.Events.Domain.Events.Entities;
using EventFlow.Events.Infrastructure.DbContexts;

namespace EventFlow.Events.Infrastructure.Events;

public class EventRepository(EventsDbContext context) : IEventRepository
{
    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }
}