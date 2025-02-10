﻿using EventFlow.Events.Application.TicketTypes.GetTicketType;
using EventFlow.Events.Application.TicketTypes.GetTicketTypes;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.TicketTypes;

internal static class GetTicketTypes
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("ticket-types", async (Guid eventId, ISender sender) =>
        {
            Result<IReadOnlyCollection<TicketTypeResponse>> result = await sender.Send(
                new GetTicketTypesQuery(eventId));

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.TicketTypes);
    }
}
