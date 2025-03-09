﻿namespace EventFlow.Common.Application.EventBus;

public interface IEventBus
{
    Task PublishAsync<TEvent>(TEvent integrationEvent, CancellationToken cancellationToken = default) 
        where TEvent : IIntegrationEvent;
}