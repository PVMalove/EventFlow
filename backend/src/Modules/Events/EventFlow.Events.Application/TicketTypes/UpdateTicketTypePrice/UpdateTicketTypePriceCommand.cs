using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.TicketTypes.UpdateTicketTypePrice;

public sealed record UpdateTicketTypePriceCommand(Guid TicketTypeId, decimal Price) : ICommand;
