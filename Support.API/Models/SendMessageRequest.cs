namespace API.Models
{
    public class SendMessageRequest
    {
        public Guid SessionId { get; set; }
        public Guid? AgentId { get; set; }
        public string Body { get; set; }
    }
}
