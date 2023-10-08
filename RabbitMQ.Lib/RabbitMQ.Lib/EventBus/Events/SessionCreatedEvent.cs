using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

namespace RabbitMQ.Lib.EventBus.Events
{
    public class SessionCreatedEvent : IntegrationEvent
    {
        public Guid SessionId { get; set; }
    }
}
