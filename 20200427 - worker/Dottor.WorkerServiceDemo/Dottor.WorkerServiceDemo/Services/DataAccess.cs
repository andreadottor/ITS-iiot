using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.WorkerServiceDemo.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DataAccess> _logger;

        public DataAccess(IConfiguration configuration, ILogger<DataAccess> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IEnumerable<string> GetList()
        {
            //var count = _configuration.GetValue<int>("count");
            //var count = _configuration.GetValue<int>("dataAccess:count");
            var count = _configuration.GetSection("dataAccess").GetValue<int>("count");
            _logger.LogInformation($"Configurazione count={count}");


            var list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list.Add($"Item {i}");
            }
            return list;
        }
    }
}
