using RabbitMQ.Lib.EventBus.Abstractions;
using RabbitMQ.Lib.EventBus.Events;
using static RabbitMQ.Lib.EventBus.InMemoryEventBusSubscriptionsManager;

namespace RabbitMQ.Lib.EventBus
{
    public  interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }

        event EventHandler<string> OnEventRemoved;

        void AddSubscription<T, TH>()
           where T : IntegrationEvent
           where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IntegrationEvent;

        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;

        bool HasSubscriptionsForEvent(string eventName);

        Type GetEventTypeByName(string eventName);

        SubscriptionInfo GetHandlerForEvent<T>() where T : IntegrationEvent;

        SubscriptionInfo GetHandlerForEvent(string eventName);

        string GetEventKey<T>();

        void Clear();
    }
}
