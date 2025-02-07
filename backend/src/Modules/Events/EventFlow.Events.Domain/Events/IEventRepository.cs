using EventFlow.Events.Domain.Events.Entities;

namespace EventFlow.Events.Domain.Events;

public interface IEventRepository
{
    void Insert(Event @event);
}