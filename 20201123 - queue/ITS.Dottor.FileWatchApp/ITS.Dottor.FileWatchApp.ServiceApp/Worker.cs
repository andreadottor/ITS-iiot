namespace ITS.Dottor.FileWatchApp.ServiceApp
{
    using Azure.Storage.Queues;
    using ITS.Dottor.FileWatchApp.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Text.Json;


    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private const string QUEUE_NAME = "fswatch";

        private QueueClient _queueClient;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cs = _configuration.GetConnectionString("QueueConnection");
            var rootFolder = _configuration.GetValue<string>("MontitorPath");

            // Instantiate a QueueClient which will be used to create and manipulate the queue
            _queueClient = new QueueClient(cs, QUEUE_NAME);
            // Create the queue
            _queueClient.CreateIfNotExists();

            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = rootFolder;

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // Only watch text files.
                //watcher.Filter = "*.txt";

                // Add event handlers.
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                _logger.LogInformation($"Start monitoring folder: {rootFolder}");
                //while (Console.Read() != 'q') ;

                while (!stoppingToken.IsCancellationRequested)
                {
                    //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(10000, stoppingToken);
                }
            }
        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            _logger.LogInformation($"File: {e.FullPath} {e.ChangeType}");

            var message = new FSWatchMessage
            {
                Name = e.Name,
                FullPath = e.FullPath,
                ChangeType = e.ChangeType
            };
            var json = JsonSerializer.Serialize(message);
            _queueClient.SendMessage(json);
        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            _logger.LogInformation($"File: {e.OldFullPath} renamed to {e.FullPath}");

            var message = new FSWatchMessage
            {
                Name = e.Name,
                FullPath = e.FullPath,
                ChangeType = e.ChangeType,
                OldFullPath = e.OldFullPath,
                OldName = e.OldName
            };
            var json = JsonSerializer.Serialize(message);
            _queueClient.SendMessage(json);
        }
    }
}
