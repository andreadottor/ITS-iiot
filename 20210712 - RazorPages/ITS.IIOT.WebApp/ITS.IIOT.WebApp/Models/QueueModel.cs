namespace ITS.IIOT.WebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class QueueModel
    {
        /// <summary>
        /// Gateway / raspberry / DeviceId IoT Hub
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Id del pic
        /// </summary>
        public string QueueId { get; set; }

        /// <summary>
        /// Descrizione per l'utente finale
        /// </summary>
        public string Description { get; set; }
    }
}
