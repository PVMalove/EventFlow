using EventFlow.Common.Application.Messaging;

namespace EventFlow.Events.Application.TicketTypes.CreateTicketType;

public sealed record CreateTicketTypeCommand(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    decimal Quantity) : ICommand<Guid>;
