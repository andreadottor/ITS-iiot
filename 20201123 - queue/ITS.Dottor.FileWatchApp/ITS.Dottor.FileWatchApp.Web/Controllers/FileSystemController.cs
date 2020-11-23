namespace ITS.Dottor.FileWatchApp.Web.Controllers
{
    using ITS.Dottor.FileWatchApp.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.Cosmos.Table;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/filesystem")]
    [ApiController]
    public class FileSystemController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FileSystemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Get()
        {
            // Retrieve storage account information from connection string.
            var storageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("QueueConnection"));

            // Create a table client for interacting with the table service
            var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference("fsstate");

            var list = table.ExecuteQuery(new TableQuery<FileSystemEntity>());
            return Ok(list.ToArray());

        }
    }
}
