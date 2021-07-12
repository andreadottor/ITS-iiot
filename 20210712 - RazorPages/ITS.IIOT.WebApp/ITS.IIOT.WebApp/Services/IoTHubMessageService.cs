namespace ITS.IIOT.WebApp.Services
{
    using ITS.IIOT.WebApp.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class IoTHubMessageService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public IoTHubMessageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("IoTHub");
        }

        public async Task SendMessageAsync(string deviceId, string queueId, int number)
        {
            var serviceClient = ServiceClient.CreateFromConnectionString(_connectionString);
            var message = new QueueMessaggeModel
            {
                QueueId = queueId,
                Number = number
            };
            var json = JsonSerializer.Serialize(message);

            var commandMessage =
                        new Message(Encoding.ASCII.GetBytes(json));
            await serviceClient.SendAsync(deviceId, commandMessage);
        }
    }
}
