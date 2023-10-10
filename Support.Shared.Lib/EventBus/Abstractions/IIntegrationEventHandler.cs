using Shared.Library.EventBus.Events;

namespace Shared.Library.EventBus.Abstractions
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
