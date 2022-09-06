using Grpc.Core;
using grpcMessageServer;
using System.Xml.Linq;

namespace grpcServer.Services
{
    public class MessageService : Message.MessageBase
    {

        #region Unary RPC

        //public override async Task<MessageResponse> SendMessage(MessageRequest request, ServerCallContext context)
        //{
        //    Console.WriteLine($"Message : {request.Message} | Name: {request.Name}");

        //    return new MessageResponse()
        //    {
        //        Message = "Mesaj başarıyla alınmıştır"
        //    };
           
        //}

        #endregion


        #region Server Stream RPC

        //public override async Task SendMessage(MessageRequest request,
        //    IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        //{
        //    Console.WriteLine($"Message : {request.Message} | Name: {request.Name}");

        //    for (int i = 0; i < 10; i++)
        //    {
        //        await Task.Delay(200);
        //        responseStream.WriteAsync(new MessageResponse()
        //        {
        //            Message = "Merhaba " + i.ToString()
        //        });
        //    }
        //}

        #endregion

        public override async Task<MessageResponse> SendMessage(IAsyncStreamReader<MessageRequest> requestStream, ServerCallContext context)
        {

            while (await requestStream.MoveNext(context.CancellationToken))
            {
                Console.WriteLine($"Message : {requestStream.Current.Message} | Name: {requestStream.Current.Name}");
            }

            return new MessageResponse()
            {
                Message = "Veri alınmıştır..."
            };
        }
    }
}
