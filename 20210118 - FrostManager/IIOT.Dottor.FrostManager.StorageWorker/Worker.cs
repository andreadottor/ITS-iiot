namespace IIOT.Dottor.FrostManager.StorageWorker
{
    using IIOT.Dottor.FrostManager.Application;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMessageService _messageService;
        public Worker(ILogger<Worker> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _messageService.StartReceiveMessagesFromSubscriptionAsync(
                message =>
            {
                _logger.LogInformation("DEVICE: {0}, TEMP: {1}", message.DeviceId, message.TemperatureDesired);
            });

            while (!stoppingToken.IsCancellationRequested)
            {
                   await Task.Delay(10000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await _messageService.StopReceiveMessagesFromSubscriptionAsync();
            await base.StopAsync(cancellationToken);
        }
    }
}
