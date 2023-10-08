namespace SessionCoordinatorService.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int WorkStartHourAt { get; set; }
        public int WorkFinishHourAt { get; set; }
        public List<Agent> Agents { get; set; }
        public bool Active { get; set; }

    }
}
