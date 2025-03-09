using EventFlow.Common.Application.Messaging;

namespace EventFlow.Ticketing.Application.Tickets.ArchiveTicketsForEvent;

public sealed record ArchiveTicketsForEventCommand(Guid EventId) : ICommand;
