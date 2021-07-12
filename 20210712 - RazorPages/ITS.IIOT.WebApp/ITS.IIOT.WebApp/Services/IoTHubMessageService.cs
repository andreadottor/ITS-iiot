namespace ITS.IIOT.WebApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IoTHubMessageService
    {


        public Task SendMessage(string deviceId, string queueId, int number)
        {
            // uso dell'iot hub
            return Task.CompletedTask;
        }
    }
}
