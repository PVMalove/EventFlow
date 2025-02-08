using EventFlow.Events.Application.Abstractions.Clock;
using EventFlow.Events.Application.Abstractions.Data;
using EventFlow.Events.Application.Abstractions.Messaging;
using EventFlow.Events.Domain.Abstractions;
using EventFlow.Events.Domain.Events;
using EventFlow.Events.Domain.Events.Entities;

namespace EventFlow.Events.Application.Events.CancelEvent;

internal sealed class CancelEventCommandHandler(
    IDateTimeProvider dateTimeProvider,
    IEventRepository eventRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CancelEventCommand>
{
    public async Task<Result> Handle(CancelEventCommand request, CancellationToken cancellationToken)
    {
        Event? @event = await eventRepository.GetAsync(request.EventId, cancellationToken);

        if (@event is null)
        {
            return Result.Failure(EventErrors.NotFound(request.EventId));
        }

        Result result = @event.Cancel(dateTimeProvider.UtcNow);

        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
