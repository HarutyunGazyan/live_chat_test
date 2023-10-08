namespace SessionCoordinatorService.Entities
{
    public class AgentSeniority
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int SeniorityMultiplier { get; set; }
        public List<Agent> Agents { get; set; }
        public int Priority { get; set; }
    }
}
