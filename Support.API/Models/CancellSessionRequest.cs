namespace API.Models
{
    public class CancellSessionRequest
    {
        public Guid SessionId { get; set; }
        public Guid? AgentId { get; set; }
    }
}
