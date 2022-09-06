using Grpc.Net.Client;
using grpcServer;

var channel = GrpcChannel.ForAddress("https://localhost:5001");
var greetClient = new Greeter.GreeterClient(channel);

HelloReply result = await greetClient.SayHelloAsync(new HelloRequest { Name = "Selamlar Efendim." });

Console.WriteLine(result.Message);
