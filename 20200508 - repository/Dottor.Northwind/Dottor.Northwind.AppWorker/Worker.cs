using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Process p = Process.GetCurrentProcess();
            PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set", "_Total");
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");

            while (!stoppingToken.IsCancellationRequested)
            {
                double ram = ramCounter.NextValue();
                double cpu = cpuCounter.NextValue();

                Console.WriteLine("RAM: " + (ram / 1024 / 1024) + " MB; CPU: " + (cpu) + " %");
                await Task.Delay(1000, stoppingToken);
            }
        }



    }
}
