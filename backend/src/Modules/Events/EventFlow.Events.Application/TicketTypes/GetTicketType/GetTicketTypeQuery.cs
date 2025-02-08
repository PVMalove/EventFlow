using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.TicketTypes.GetTicketType;

public sealed record GetTicketTypeQuery(Guid TicketTypeId) : IQuery<TicketTypeResponse>;
