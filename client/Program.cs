// See https://aka.ms/new-console-template for more information

using Dummey;
using Grpc.Core;

Console.WriteLine("Hello, World!");
const string target = "127.0.0.1:50051";

Channel channel = new(target, ChannelCredentials.Insecure);

channel.ConnectAsync().ContinueWith((t) =>
{
    if (t.Status == TaskStatus.RanToCompletion) Console.WriteLine("The client connected successfullt");
}).Wait();


var client = new DummeyService.DummeyServiceClient(channel);

await channel.ShutdownAsync();
Console.ReadKey();