using EventFlow.Events.Application.Abstractions.Data;
using EventFlow.Events.Domain.Events;
using EventFlow.Events.Domain.Events.Entities;
using MediatR;

namespace EventFlow.Events.Application.Events.CreateEvent;

internal sealed class CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = Event.Create(
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndsAtUtc);

        eventRepository.Insert(@event);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return @event.Id;
    }
}
