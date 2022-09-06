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


var messageClient = new Message.MessageClient(channel);
var response = messageClient.SendMessage(new MessageRequest()
{
    Message = "Bu bir mesaj gönderme denemesidir",
    Name = "beyazskorsky"
});

CancellationTokenSource tokenSource = new();

while (await response.ResponseStream.MoveNext(tokenSource.Token))
{
    Console.WriteLine(response.ResponseStream.Current);
}

Console.ReadKey();