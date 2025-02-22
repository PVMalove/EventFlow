using Microsoft.AspNetCore.Routing;

namespace EventFlow.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}