using MediatR;

namespace EventFlow.Common.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    DateTime OccurredOnUtc { get; }
}