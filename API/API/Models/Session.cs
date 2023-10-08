namespace API.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
