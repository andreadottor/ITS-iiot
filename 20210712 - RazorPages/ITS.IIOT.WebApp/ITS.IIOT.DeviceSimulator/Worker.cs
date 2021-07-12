namespace ITS.IIOT.DeviceSimulator
{
    using ITS.IIOT.DeviceSimulator.Models;
    using Microsoft.Azure.Devices.Client;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _connectionString;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetConnectionString("Device");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var s_deviceClient = DeviceClient.CreateFromConnectionString(_connectionString);

            Console.WriteLine("\nReceiving cloud to device messages from service");
            while (true)
            {
                Message receivedMessage = await s_deviceClient.ReceiveAsync();
                if (receivedMessage == null) continue;

                var json = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                Console.WriteLine("Received message: {0}", json);

                var obj = JsonSerializer.Deserialize<QueueMessaggeModel>(json);
                await s_deviceClient.CompleteAsync(receivedMessage);

                // invio al pic i dati
                
            }
        }
    }
}
