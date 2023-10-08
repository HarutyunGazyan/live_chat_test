namespace SessionCoordinatorService.Entities
{
    public class SessionMessage
    {
        public Guid Id { get; set; }
        public Guid AgentId { get; set; }
        public Agent Agent { get; set; }
        public Guid SessionId { get; set; }
        public string SentBy { get; set; }
        public DateTime SentAt { get; set; }
        public string MessageBody { get; set; }

    }
}