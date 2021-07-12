namespace ITS.IIOT.WebApp.Pages
{
    using ITS.IIOT.WebApp.Models;
    using ITS.IIOT.WebApp.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly QueueService _queueService;

        public IEnumerable<QueueModel> List { get; set; }

        public IndexModel(ILogger<IndexModel> logger, 
                          QueueService queueService)
        {
            _logger = logger;
            _queueService = queueService;
        }

        public void OnGet()
        {
            List = _queueService.GetQueues();
        }

        public void OnPost()
        {

        }
    }
}
