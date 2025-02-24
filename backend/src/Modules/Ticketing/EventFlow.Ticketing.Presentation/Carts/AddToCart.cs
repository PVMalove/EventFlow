using EventFlow.Common.Domain.Abstractions;
using EventFlow.Common.Presentation.ApiResults;
using EventFlow.Common.Presentation.Endpoints;
using EventFlow.Ticketing.Application.Carts.AddItemToCart;
using EventFlow.Ticketing.Presentation.Carts.Request;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventFlow.Ticketing.Presentation.Carts;

internal sealed class AddToCart : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("carts/add", async (AddToCartRequest request, ISender sender) =>
            {
                Result result = await sender.Send(
                    new AddItemToCartCommand(
                        request.CustomerId,
                        request.TicketTypeId,
                        request.Quantity));

                return result.Match(() => Results.Ok(), ApiResults.Problem);
            })
            .WithTags(Tags.Carts);
    }
}