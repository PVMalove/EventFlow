using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.Events.PublishEvent;

public sealed record PublishEventCommand(Guid EventId) : ICommand;
