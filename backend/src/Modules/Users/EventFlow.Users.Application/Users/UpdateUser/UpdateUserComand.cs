using EventFlow.Common.Application.Messaging;

namespace EventFlow.Users.Application.Users.UpdateUser;

public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand;
