using EventFlow.Common.Domain.Abstractions;
using MediatR;

namespace EventFlow.Common.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;