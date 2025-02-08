using EventFlow.Events.Application.Abstractions.Messaging;

namespace EventFlow.Events.Application.Events.GetEvents;

public sealed record GetEventsQuery : IQuery<IReadOnlyCollection<EventResponse>>;
