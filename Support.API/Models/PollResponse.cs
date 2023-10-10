namespace API.Models
{
    public class PollResponse
    {
        public string AgentName { get; set; }
        public string SentBy { get; set; }
        public DateTime SentAt { get; set; }
        public string MessageBody { get; set; }

    }
}
