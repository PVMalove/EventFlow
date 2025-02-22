using EventFlow.Events.Application.Events.CreateEvent;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Events.Presentation.Events.Request;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Events;

internal class CreateEvent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (CreateEventRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateEventCommand(
                    request.CategoryId,
                    request.Title,
                    request.Description,
                    request.Location,
                    request.StartsAtUtc,
                    request.EndsAtUtc));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Events);
    }
}