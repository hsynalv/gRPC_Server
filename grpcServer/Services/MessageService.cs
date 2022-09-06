using Grpc.Core;
using grpcMessageServer;

namespace grpcServer.Services
{
    public class MessageService : Message.MessageBase
    {


        public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"Message : {request.Message} | Name: {request.Name}");

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(200);
                responseStream.WriteAsync(new MessageResponse()
                {
                    Message = "Merhaba " + i.ToString()
                });
            }
        }
    }
}
