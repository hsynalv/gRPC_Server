using Grpc.Core;
using grpcMessageServer;

namespace grpcServer.Services
{
    public class MessageService : Message.MessageBase
    {
        public override async Task<MessageResponse> SendMessage(MessageRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Message : {request.Message} | Name: {request.Name}");

            return new MessageResponse()
            {
                Message = "Mesaj başarıyla alınmıştır"
            };
        }
    }
}
