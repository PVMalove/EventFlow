using EventFlow.Events.Application.Events.SearchEvents;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Events;

internal class SearchEvents : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/search", async (
                ISender sender,
                Guid? categoryId,
                DateTime? startDate,
                DateTime? endDate,
                int page = 0,
                int pageSize = 15) =>
            {
                Result<SearchEventsResponse> result = await sender.Send(
                    new SearchEventsQuery(categoryId, startDate, endDate, page, pageSize));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Events);
    }
}