using EventFlow.Events.Application.TicketTypes.GetTicketType;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.TicketTypes;

internal class GetTicketType : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ticket-types/{id}", async (Guid id, ISender sender) =>
            {
                Result<TicketTypeResponse> result = await sender.Send(new GetTicketTypeQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.TicketTypes);
    }
}