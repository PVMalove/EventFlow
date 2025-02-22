using EventFlow.Events.Application.Events.RescheduleEvent;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Events.Presentation.Events.Request;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Events;

internal class RescheduleEvent : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("events/{id}/reschedule", async (Guid id, RescheduleEventRequest request, ISender sender) =>
            {
                Result result = await sender.Send(
                    new RescheduleEventCommand(id, request.StartsAtUtc, request.EndsAtUtc));

                return result.Match(Results.NoContent, ApiResults.Problem);
            })
            .WithTags(Tags.Events);
    }
}