using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

namespace RabbitMQ.Lib.EventBus.Events
{
    public class SessionCancelledEvent : IntegrationEvent
    {
        public Guid SessionId { get; set; }
        public string CancelledBy { get; set; }
    }
}
