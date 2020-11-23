namespace ITS.Dottor.FileWatchApp.Web.Services
{
    using Azure.Storage.Queues;
    using Azure.Storage.Queues.Models;
    using ITS.Dottor.FileWatchApp.Models;
    using ITS.Dottor.FileWatchApp.Web.Models;
    using Microsoft.Azure.Cosmos.Table;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public class QueueManageService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private const string QUEUE_NAME = "fswatch";
        private readonly ILogger<QueueManageService> _logger;

        public QueueManageService(IConfiguration configuration, ILogger<QueueManageService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cs = _configuration.GetConnectionString("QueueConnection");
            var queueClient = new QueueClient(cs, QUEUE_NAME);

            // Retrieve storage account information from connection string.
            var storageAccount = CloudStorageAccount.Parse(cs);

            // Create a table client for interacting with the table service
            var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference("fsstate");
            await table.CreateIfNotExistsAsync();




            while (!stoppingToken.IsCancellationRequested)
            {

                var message = await queueClient.ReceiveMessageAsync();
                if (message != null && message.Value != null)
                {
                    try
                    {
                        var obj = message.Value.Body.ToObjectFromJson<FSWatchMessage>();
                        // var obj2 = JsonSerializer.Deserialize<FSWatchMessage>(message.Value.MessageText);
                       
                        switch (obj.ChangeType)
                        {
                            case System.IO.WatcherChangeTypes.Created:
                                await Insert(table, obj.Name);
                                await queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt);
                                break;
                            case System.IO.WatcherChangeTypes.Deleted:
                                await Delete(table, obj.Name);
                                await queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt);
                                break;
                            //case System.IO.WatcherChangeTypes.Changed:
                            //    break;
                            case System.IO.WatcherChangeTypes.Renamed:
                                await Delete(table, obj.OldName);
                                await Insert(table, obj.Name);
                                await queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt);
                                break;
                                //case System.IO.WatcherChangeTypes.All:
                                //    break;
                                //default:
                                //    break;
                        }

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error on manage queue");
                    }
                }
                else
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }


        }

        private static async Task Insert(CloudTable table, string name)
        {
            var entity = new FileSystemEntity(name);
            TableOperation insertOperationRename = TableOperation.Insert(entity);
            TableResult resultInsertRename = await table.ExecuteAsync(insertOperationRename);
        }

        private static async Task Delete(CloudTable table, string name)
        {
            TableOperation retrieveOperation = TableOperation.Retrieve<FileSystemEntity>("ITS", name);
            TableResult result = await table.ExecuteAsync(retrieveOperation);
            var entityToDelete = result.Result as FileSystemEntity;
            TableOperation deleteOperation = TableOperation.Delete(entityToDelete);
            TableResult resultDelete = await table.ExecuteAsync(deleteOperation);
        }
    }
}
