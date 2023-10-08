namespace SessionCoordinatorService.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TimeOnly WorkStartAt { get; set; }
        public TimeOnly WorkFinishAt { get; set; }
        public List<Agent> Agents { get; set; }
    }
}
