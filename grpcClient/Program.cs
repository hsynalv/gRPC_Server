using Grpc.Net.Client;
using grpcMessageClient;
using grpcServer;

var channel = GrpcChannel.ForAddress("https://localhost:5001");

#region Create base client project

//var greetClient = new Greeter.GreeterClient(channel);
//HelloReply result = await greetClient.SayHelloAsync(new HelloRequest { Name = "Selamlar Efendim." });
//Console.WriteLine(result.Message);

#endregion


#region Unary RPC

//var messageClient = new Message.MessageClient(channel);
//var response = await messageClient.SendMessageAsync(new MessageRequest()
//{
//    Message = "Bu bir mesaj gönderme denemesidir",
//    Name = "beyazskorsky"
//});
//Console.WriteLine(response.Message);

#endregion


#region Server Streaming RPC

//var messageClient = new Message.MessageClient(channel);
//var response = messageClient.SendMessage(new MessageRequest()
//{
//    Message = "Bu bir mesaj gönderme denemesidir",
//    Name = "beyazskorsky"
//});

//CancellationTokenSource tokenSource = new();

//while (await response.ResponseStream.MoveNext(tokenSource.Token))
//{
//    Console.WriteLine(response.ResponseStream.Current);
//}

#endregion

#region Client Streaming RPC

var messageClient = new Message.MessageClient(channel);
var request = messageClient.SendMessage();
for (int i = 0; i < 10; i++)
{
    await Task.Delay(1000);
    await request.RequestStream.WriteAsync(new MessageRequest()
    {
        Name = "beyazskorsky",
        Message = "Mesaj" + i
    });
}

await request.RequestStream.CompleteAsync();
Console.WriteLine(request.ResponseAsync.Result.Message);
//Console.WriteLine((await request.ResponseAsync).Message);


#endregion




Console.ReadKey();