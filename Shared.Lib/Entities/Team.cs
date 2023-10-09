namespace Shared.Library.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime WorkStartHourAt { get; set; }
        public DateTime WorkFinishHourAt { get; set; }
        public List<Agent> Agents { get; set; }
        public bool Active { get; set; }

    }
}
