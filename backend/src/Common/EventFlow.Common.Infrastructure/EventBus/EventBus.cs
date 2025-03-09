using EventFlow.Common.Application.EventBus;
using MassTransit;

namespace EventFlow.Common.Infrastructure.EventBus;

internal sealed class EventBus(IBus bus) : IEventBus
{
    public async Task PublishAsync<TEvent>(TEvent integrationEvent, CancellationToken cancellationToken = default) where TEvent : IIntegrationEvent
    {
        await bus.Publish(integrationEvent, cancellationToken);
    }
}