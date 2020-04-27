using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dottor.WorkerServiceDemo.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dottor.WorkerServiceDemo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDataAccess _dataAccess;

        public Worker(ILogger<Worker> logger, 
                      IDataAccess dataAcecss)
        {
            _logger = logger;
            _dataAccess = dataAcecss;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var list = _dataAccess.GetList();
            _logger.LogInformation($"Sono presenti {list.Count()} elementi.");


            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // faccio qualcosa
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Errore nel metodo ExecuteAsync", ex);
                }

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
