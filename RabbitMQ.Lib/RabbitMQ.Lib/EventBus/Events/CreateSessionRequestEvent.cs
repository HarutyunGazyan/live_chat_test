using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

namespace RabbitMQ.Lib.EventBus.Events
{
    public class CreateSessionRequestEvent : IntegrationEvent
    {
        public Guid SessionId { get; set; }
    }
}
