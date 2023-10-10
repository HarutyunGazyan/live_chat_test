namespace Shared.Library.EventBus.Events
{
    public class SessionCancelledEvent : IntegrationEvent
    {
        public SessionCancelledEvent()
        {
            
        }
        public Guid SessionId { get; set; }
        public string CancelledBy { get; set; }
    }
}
