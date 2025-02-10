using EventFlow.Common.Application.Messaging;

namespace EventFlow.Events.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
