using EventFlow.Events.Domain.Events.Entities;

namespace EventFlow.Events.Domain.Events;

public interface IEventRepository
{
    Task<Event?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Event @event);
}
