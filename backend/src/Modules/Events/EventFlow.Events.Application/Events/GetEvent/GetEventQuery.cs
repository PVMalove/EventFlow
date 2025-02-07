using MediatR;

namespace EventFlow.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(Guid EventId) : IRequest<EventResponse?>;