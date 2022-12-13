using Grpc.App;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7273");
var client = new Greeter.GreeterClient(channel);
var response = await client.SayHelloAsync(new HelloRequest() { Name = "From Client" });
Console.WriteLine(response);