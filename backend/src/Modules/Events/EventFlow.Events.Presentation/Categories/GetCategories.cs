using EventFlow.Events.Application.Categories.GetCategories;
using EventFlow.Events.Application.Categories.GetCategory;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Categories;

internal class GetCategories : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("categories", async (ISender sender) =>
            {
                Result<IReadOnlyCollection<CategoryResponse>> result = await sender.Send(new GetCategoriesQuery());

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Categories);
    }
}