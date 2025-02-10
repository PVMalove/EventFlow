using EventFlow.Events.Application.Categories.ArchiveCategory;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Events.Presentation.ApiResults;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Categories;

internal static class ArchiveCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}/archive", async (Guid id, ISender sender) =>
        {
            Result result = await sender.Send(new ArchiveCategoryCommand(id));

            return result.Match(() => Results.Ok(), ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
