using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dottor.Northwind.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dottor.Northwind.AppWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ICategoriesService _categoriesService;

        public Worker(ILogger<Worker> logger, ICategoriesService categoriesService)
        {
            _logger = logger;
            _categoriesService = categoriesService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // ID
                // Date
                // CPU
                // Memory


                // appsettings 
                // interval
                // soglia -> 90 --> email


                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
