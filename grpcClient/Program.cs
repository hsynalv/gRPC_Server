using Grpc.Net.Client;
using grpcMessageClient;
using grpcServer;

var channel = GrpcChannel.ForAddress("https://localhost:5001");

//var greetClient = new Greeter.GreeterClient(channel);
//HelloReply result = await greetClient.SayHelloAsync(new HelloRequest { Name = "Selamlar Efendim." });
//Console.WriteLine(result.Message);


var messageClient = new Message.MessageClient(channel);

var response = await messageClient.SendMessageAsync(new MessageRequest()
{
    Message = "Bu bir mesaj gönderme denemesidir",
    Name = "beyazskorsky"
});

Console.WriteLine(response.Message);
Console.ReadKey();