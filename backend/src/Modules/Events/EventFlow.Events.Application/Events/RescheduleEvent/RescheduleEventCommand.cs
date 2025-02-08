using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.Events.RescheduleEvent;

public sealed record RescheduleEventCommand(Guid EventId, DateTime StartsAtUtc, DateTime? EndsAtUtc) : ICommand;
