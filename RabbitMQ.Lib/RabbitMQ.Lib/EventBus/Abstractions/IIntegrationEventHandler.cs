﻿using RabbitMQ.Lib.EventBus.Events;

namespace RabbitMQ.Lib.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task<bool> Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}
