namespace SessionCoordinatorService.Entities
{
    public class Agent
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public string Name { get; set; }
        public Guid SeniorityId { get; set; }
        public AgentSeniority Seniority { get; set; }
        public List<ActiveAgentSession> ActiveAgentSessions { get; set; }

    }
}