namespace GrpcServices.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
