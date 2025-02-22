using EventFlow.Events.Application.Categories.ArchiveCategory;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Categories;

internal class ArchiveCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}/archive", async (Guid id, ISender sender) =>
            {
                Result result = await sender.Send(new ArchiveCategoryCommand(id));

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            })
            .WithTags(Tags.Categories);
    }
}