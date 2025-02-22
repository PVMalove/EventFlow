using EventFlow.Events.Application.TicketTypes.CreateTicketType;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Events.Presentation.TicketTypes.Request;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.TicketTypes;

internal class CreateTicketType : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("ticket-types", async (CreateTicketTypeRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateTicketTypeCommand(
                    request.EventId,
                    request.Name,
                    request.Price,
                    request.Currency,
                    request.Quantity));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.TicketTypes);
    }
}