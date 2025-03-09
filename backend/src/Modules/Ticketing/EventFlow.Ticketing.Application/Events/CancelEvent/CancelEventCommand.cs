using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
