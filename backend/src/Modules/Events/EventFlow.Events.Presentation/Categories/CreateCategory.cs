using EventFlow.Events.Application.Categories.CreateCategory;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Events.Presentation.Categories.Request;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Categories;

internal class CreateCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("categories", async (CreateCategoryRequest request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateCategoryCommand(request.Name));

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Categories);
    }
}