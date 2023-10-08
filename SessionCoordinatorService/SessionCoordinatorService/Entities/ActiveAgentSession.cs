namespace SessionCoordinatorService.Entities
{
    public class ActiveAgentSession
    {
        public Guid Id { get; set; }
        public Guid AgentId { get; set; }
        public Agent Agent { get; set; }
        public Guid SessionId { get; set; }
    }
}