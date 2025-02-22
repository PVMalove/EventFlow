using EventFlow.Events.Application.Categories.UpdateCategory;
using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Events.Presentation.Categories.Request;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Events.Presentation.Categories;

internal class UpdateCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}", async (Guid id, UpdateCategoryRequest request, ISender sender) =>
            {
                Result result = await sender.Send(new UpdateCategoryCommand(id, request.Name));

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            })
            .WithTags(Tags.Categories);
    }
}