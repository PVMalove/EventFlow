using EventFlow.Common.Application.EventBus;
using EventFlow.Common.Application.Exceptions;
using EventFlow.Common.Application.Messaging;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Users.Application.Users.GetUser;
using EventFlow.Users.Domain.Users;
using EventFlow.Users.IntegrationEvents;
using MediatR;

namespace EventFlow.Users.Application.Users.RegisterUser;

internal sealed class UserRegisteredDomainEventHandler(ISender sender, IEventBus eventBus)
    : IDomainEventHandler<UserRegisteredDomainEvent>
{
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        Result<UserResponse> result = await sender.Send(new GetUserQuery(notification.UserId), cancellationToken);

        if (result.IsFailure)
        {
            throw new EventFlowException(nameof(GetUserQuery), result.Error);
        }

        await eventBus.PublishAsync(
            new UserRegisteredIntegrationEvent(
                notification.Id,
                notification.OccurredOnUtc,
                result.Value.Id,
                result.Value.Email,
                result.Value.FirstName,
                result.Value.LastName),
            cancellationToken);
    }
}