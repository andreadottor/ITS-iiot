using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dottor.Northwind.Data;
using Dottor.Northwind.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dottor.Northwind.AppWorker
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
                    services.AddSingleton<ICategoriesRepository, CategoriesRepository>();
                    services.AddSingleton<ICustomersRepository, CustomersRepository>();
                    services.AddSingleton<ICategoriesService, CategoriesService>();

                    services.AddHostedService<Worker>();
                });
    }
}
