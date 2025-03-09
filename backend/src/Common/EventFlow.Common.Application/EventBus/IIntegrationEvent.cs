namespace EventFlow.Common.Application.EventBus;

public class IIntegrationEvent
{
    Guid Id { get; }
    
    DateTime OccurredOnUtc { get; }
}