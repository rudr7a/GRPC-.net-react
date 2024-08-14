using Microsoft.EntityFrameworkCore;
using GrpcServices.Models;

namespace GrpcServices.Data
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options)
            : base(options)
        {
        }

        public DbSet<Message>? Messages { get; set; }
    }
}
