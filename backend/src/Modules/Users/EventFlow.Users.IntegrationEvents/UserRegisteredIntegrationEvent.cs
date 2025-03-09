using EventFlow.Common.Application.EventBus;

namespace EventFlow.Users.IntegrationEvents;

public sealed class UserRegisteredIntegrationEvent : IntegrationEvent
{
    public Guid UserId { get; init; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public UserRegisteredIntegrationEvent(Guid id, DateTime occurredOnUtc, Guid userId, string email, string firstName,
        string lastName) : base(id, occurredOnUtc)
    {
        UserId = userId;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}