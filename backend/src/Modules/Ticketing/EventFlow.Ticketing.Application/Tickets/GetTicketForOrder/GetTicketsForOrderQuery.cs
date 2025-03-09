using EventFlow.Common.Application.Messaging;
using EventFlow.Ticketing.Application.Tickets.GetTicket;

namespace EventFlow.Ticketing.Application.Tickets.GetTicketForOrder;

public sealed record GetTicketsForOrderQuery(Guid OrderId) : IQuery<IReadOnlyCollection<TicketResponse>>;
