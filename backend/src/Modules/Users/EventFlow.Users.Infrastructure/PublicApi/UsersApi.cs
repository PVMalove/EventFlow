using EventFlow.Common.Domain.Abstractions;
using EventFlow.Users.Application.Users.GetUser;
using EventFlow.Users.PublicApi;
using MediatR;
using UserResponse = EventFlow.Users.PublicApi.UserResponse;


namespace EventFlow.Users.Infrastructure.PublicApi;

internal sealed class UsersApi(ISender sender) : IUsersApi
{
    public async Task<UserResponse?> GetAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        Result<Application.Users.GetUser.UserResponse> result =
            await sender.Send(new GetUserQuery(userId), cancellationToken);

        if (result.IsFailure)
        {
            return null;
        }

        return new UserResponse(
            result.Value.Id,
            result.Value.Email,
            result.Value.FirstName,
            result.Value.LastName);
    }
}
