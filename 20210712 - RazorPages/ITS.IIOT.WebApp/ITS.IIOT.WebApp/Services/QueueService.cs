namespace ITS.IIOT.WebApp.Services
{
    using ITS.IIOT.WebApp.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class QueueService
    {
        private readonly List<QueueModel> _list;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly ILogger<QueueService> _logger;

        public QueueService(IConfiguration configuration, ILogger<QueueService> logger)
        {
            _list = new List<QueueModel>();
            _list.Add(new QueueModel
            {
                DeviceId = "device-1",
                QueueId = "banco-1",
                Description = "Banco 1 della salumeria"
            });
            _list.Add(new QueueModel
            {
                DeviceId = "device-1",
                QueueId = "banco-2",
                Description = "Banco 2 della salumeria"
            });
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("db");
            _logger = logger;
        }

        public IEnumerable<QueueModel> GetQueues()
        {
            return _list;
        }

        public QueueModel GetById(string queueId)
        {
            return _list.FirstOrDefault(x => x.QueueId == queueId);
        }
    }
}
