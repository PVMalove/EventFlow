using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
