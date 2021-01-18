namespace ConsoleApp1
{
    using Grpc.Net.Client;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var result = client.SayHello(new HelloRequest() { 
                Name = "Andrea"
            });

            Console.WriteLine(result.Message);
            Console.ReadLine();

        }
    }
}
