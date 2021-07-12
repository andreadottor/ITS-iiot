using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.IIOT.WebApp.Models;
using ITS.IIOT.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITS.IIOT.WebApp.Pages.Queues
{
    public class ManageModel : PageModel
    {
        private readonly QueueService _queueService;
        private readonly IoTHubMessageService _messageService;

        public QueueModel Queue { get; set; }

        [BindProperty]
        public int Counter { get; set; }

        public ManageModel(QueueService queueService, 
                           IoTHubMessageService messageService)
        {
            _queueService = queueService;
            _messageService = messageService;
        }

        public void OnGet(string id)
        {
            Queue = _queueService.GetById(id);
        }

        public void OnPost(string id)
        {
            Queue = _queueService.GetById(id);
            Counter++;
            ModelState.Clear();

            // invio all'IoT Hub il messaggio con il counter
            //var device = Queue.DeviceId;
            //var pic = id; //Queue.QueueId
            //var number = Counter;

            _messageService.SendMessage(Queue.DeviceId, 
                                        Queue.QueueId, 
                                        Counter);
        }
    }
}
