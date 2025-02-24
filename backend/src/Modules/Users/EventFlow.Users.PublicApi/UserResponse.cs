namespace EventFlow.Users.PublicApi;

public sealed record UserResponse(Guid Id, string Email, string FirstName, string LastName);
