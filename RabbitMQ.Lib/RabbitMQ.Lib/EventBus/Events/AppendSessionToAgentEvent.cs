namespace RabbitMQ.Lib.EventBus.Events
{
    public class AppendSessionToAgentEvent : IntegrationEvent
    {
        public Guid SessionId { get; set; }
    }
}
