using EventFlow.Common.Application.Messaging;
using EventFlow.Events.Domain.Events;

namespace EventFlow.Events.Application.Events.RescheduleEvent;

internal sealed class EventRescheduledDomainEventHandler : IDomainEventHandler<EventRescheduledDomainEvent>
{
    public Task Handle(EventRescheduledDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
