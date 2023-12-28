// See https://aka.ms/new-console-template for more information
using Grpc.Core;

Console.WriteLine("Hello, World!");
const int Port = 50051;
Server server = null;
try
{
    server = new()
    {
        Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }

    };

    server.Start();
    Console.WriteLine("The server is listning on post {0}", Port);
    Console.ReadKey();

}
catch (IOException ex)
{
    Console.WriteLine("Server filed" + ex.Message);
    throw;
}
finally
{
    if (server is not null) server.ShutdownAsync().Wait();
}