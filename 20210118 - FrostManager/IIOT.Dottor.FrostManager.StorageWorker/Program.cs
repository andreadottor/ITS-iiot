namespace IIOT.Dottor.FrostManager.StorageWorker
{
    using IIOT.Dottor.FrostManager.Application;
    using IIOT.Dottor.FrostManager.Application.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IMessageService, ServiceBusService>();
                    services.AddHostedService<Worker>();
                });
    }
}
