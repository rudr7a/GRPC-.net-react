using Grpc.Core;
using GrpcServices.Data;
using GrpcServices.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcServices.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly MessageContext _context;

        public GreeterService(ILogger<GreeterService> logger, MessageContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Saying hello to {request.Name}");

            var message = new Message
            {
                UserId = request.Name,
                Content = $"Hello, {request.Name}!"
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return new HelloReply
            {
                Message = message.Content
            };
        }
    }
}
