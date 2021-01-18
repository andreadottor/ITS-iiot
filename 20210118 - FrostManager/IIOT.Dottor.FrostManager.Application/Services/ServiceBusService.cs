namespace IIOT.Dottor.FrostManager.Application.Services
{
    using Azure.Messaging.ServiceBus;
    using IIOT.Dottor.FrostManager.Application.Models;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ServiceBusService : IMessageService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _topicName;
        private readonly string _subscriptionName;

        public ServiceBusService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("ServiceBus");
            _topicName = configuration["TopicName"] ?? "frost";
            _subscriptionName = configuration["SubscriptionName"];
        }

        public async Task SendDataAsync(TemperatureMessage message)
        {
            var data = JsonSerializer.Serialize(message);

            await using (ServiceBusClient client = new ServiceBusClient(_connectionString))
            {
                ServiceBusSender sender = client.CreateSender(_topicName);
                await sender.SendMessageAsync(new ServiceBusMessage(data));
            }
        }

        ServiceBusProcessor processor;
        public async Task StartReceiveMessagesFromSubscriptionAsync(
                                        Action<TemperatureMessage> processMessageFunc)
        {
            if (string.IsNullOrWhiteSpace(_subscriptionName))
                throw new ArgumentNullException("Parameter SubscriptionName cannot be null or empty");

            ServiceBusClient client = new ServiceBusClient(_connectionString);

            processor = client.CreateProcessor(_topicName, _subscriptionName, new ServiceBusProcessorOptions());
            processor.ProcessMessageAsync += async args => 
            {
                string body = args.Message.Body.ToString();
                var message = JsonSerializer.Deserialize<TemperatureMessage>(body);
                processMessageFunc.Invoke(message);
                await args.CompleteMessageAsync(args.Message);
            };
            processor.ProcessErrorAsync += ErrorHandler;
            await processor.StartProcessingAsync();
        }

        public async Task StopReceiveMessagesFromSubscriptionAsync()
        {
            if (processor != null)
                await processor.StopProcessingAsync();
        }

        static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Debug.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }



   
    }
}
