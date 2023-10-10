namespace Shared.Library.EventBus.Events
{
    public class SessionGeneratedEvent : IntegrationEvent
    {
        public Guid SessionId { get; set; }
    }
}
