namespace RabbitMQ.Lib.EventBus.Events
{
    public class SessionGeneratedEvent : IntegrationEvent
    {
        public Guid SessionId { get; set; }
    }
}
