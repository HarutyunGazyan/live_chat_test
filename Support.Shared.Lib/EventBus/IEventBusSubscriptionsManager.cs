using Shared.Library.EventBus.Abstractions;
using Shared.Library.EventBus.Events;
using static Shared.Library.EventBus.InMemoryEventBusSubscriptionsManager;

namespace Shared.Library.EventBus
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
