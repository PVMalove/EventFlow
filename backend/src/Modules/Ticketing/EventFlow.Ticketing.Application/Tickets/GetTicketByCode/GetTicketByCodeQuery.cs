using EventFlow.Common.Application.Messaging;
using EventFlow.Ticketing.Application.Tickets.GetTicket;

namespace EventFlow.Ticketing.Application.Tickets.GetTicketByCode;

public sealed record GetTicketByCodeQuery(string Code) : IQuery<TicketResponse>;
