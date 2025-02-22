using EventFlow.Events.Application.Events.GetEvent;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Events;

internal class GetEvent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id}", async (Guid id, ISender sender) =>
            {
                Result<EventResponse> result = await sender.Send(new GetEventQuery(id));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Events);
    }
}