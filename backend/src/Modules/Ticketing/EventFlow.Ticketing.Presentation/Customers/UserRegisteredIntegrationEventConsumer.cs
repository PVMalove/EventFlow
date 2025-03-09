using EventFlow.Common.Application.Exceptions;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Ticketing.Application.Customers.CreateCustomer;
using EventFlow.Users.IntegrationEvents;
using MassTransit;
using MediatR;

namespace EventFlow.Ticketing.Presentation.Customers;

public sealed class UserRegisteredIntegrationEventConsumer(ISender sender)
    : IConsumer<UserRegisteredIntegrationEvent>
{
    public async Task Consume(ConsumeContext<UserRegisteredIntegrationEvent> context)
    {
        Result result = await sender.Send(
            new CreateCustomerCommand(
                context.Message.UserId,
                context.Message.Email,
                context.Message.FirstName,
                context.Message.LastName));

        if (result.IsFailure)
        {
            throw new EventFlowException(nameof(CreateCustomerCommand), result.Error);
        }
    }
}
