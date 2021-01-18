namespace IIOT.Dottor.FrostManager.Application
{
    using IIOT.Dottor.FrostManager.Application.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessageService
    {

        Task SendDataAsync(TemperatureMessage message);

        Task StartReceiveMessagesFromSubscriptionAsync(Action<TemperatureMessage> processMessageFunc);

        Task StopReceiveMessagesFromSubscriptionAsync();
    }
}
