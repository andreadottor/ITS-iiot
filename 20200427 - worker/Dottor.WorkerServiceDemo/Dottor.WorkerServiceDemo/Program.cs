using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dottor.WorkerServiceDemo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dottor.WorkerServiceDemo
{
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
                    services.AddTransient<IDataAccess, DataAccess>();
                    //services.AddSingleton<IDataAccess, DataAccess>();
                    //services.AddScoped<IDataAccess, DataAccess>();

                    services.AddHostedService<Worker>();
                });
    }
}
