using EventFlow.Common.Application.Messaging;
using EventFlow.Events.Application.TicketTypes.GetTicketType;

namespace EventFlow.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;
