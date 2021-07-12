using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ITS.IIOT.WebApp.Models;
using ITS.IIOT.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.IIOT.WebApp.Pages.Queues
{
    public class IndexModel : PageModel
    {
        private readonly QueueService _queueService;
        private readonly IoTHubMessageService _messageService;

        public IEnumerable<QueueModel> List { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Selezionare una coda")]
        public string QueueId { get; set; }
        [BindProperty]
        public int Counter { get; set; }

        public IndexModel(QueueService queueService, 
                          IoTHubMessageService messageService)
        {
            _queueService = queueService;
            _messageService = messageService;
        }

        public void OnGet()
        {
            List = _queueService.GetQueues();
        }

        public async Task OnPost()
        {
            List = _queueService.GetQueues();

            if (ModelState.IsValid)
            {
                Counter++;
                ModelState.Clear();

                var queue = _queueService.GetById(QueueId);

                await _messageService.SendMessageAsync(queue.DeviceId,
                                            queue.QueueId,
                                            Counter);
            }
        }
    }
}
