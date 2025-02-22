using EventFlow.Events.Application.TicketTypes.UpdateTicketTypePrice;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Events.Presentation.TicketTypes.Request;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.TicketTypes;

internal class ChangeTicketTypePrice : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("ticket-types/{id}/price", async (Guid id, ChangeTicketTypePriceRequest request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdateTicketTypePriceCommand(id, request.Price));

                return result.Match(Results.NoContent, ApiResults.Problem);
            })
            .WithTags(Tags.TicketTypes);
    }
}