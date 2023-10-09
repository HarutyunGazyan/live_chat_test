namespace RabbitMQ.Lib.EventBus.Events
{
    public class MonitorSessionQueueEvent : IntegrationEvent
    {
        public Guid SessionId { get; set; }
    }
}
