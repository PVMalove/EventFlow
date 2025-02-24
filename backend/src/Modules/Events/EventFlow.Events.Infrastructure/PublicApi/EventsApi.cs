using EventFlow.Common.Domain.Abstractions;
using EventFlow.Events.Application.TicketTypes.GetTicketType;
using EventFlow.Events.PublicApi;
using MediatR;
using TicketTypeResponse = EventFlow.Events.PublicApi.TicketTypeResponse;


namespace EventFlow.Events.Infrastructure.PublicApi;

internal sealed class EventsApi(ISender sender) : IEventsApi
{
    public async Task<TicketTypeResponse?> GetTicketTypeAsync(
        Guid ticketTypeId,
        CancellationToken cancellationToken = default)
    {
        Result<Application.TicketTypes.GetTicketType.TicketTypeResponse> result =
            await sender.Send(new GetTicketTypeQuery(ticketTypeId), cancellationToken);

        if (result.IsFailure)
        {
            return null;
        }

        return new TicketTypeResponse(
            result.Value.Id,
            result.Value.EventId,
            result.Value.Name,
            result.Value.Price,
            result.Value.Currency,
            result.Value.Quantity);
    }
}
