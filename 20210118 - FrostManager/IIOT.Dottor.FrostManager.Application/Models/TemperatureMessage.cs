namespace IIOT.Dottor.FrostManager.Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TemperatureMessage
    {

        public int DeviceId { get; set; }
        public double TemperatureMeasured { get; set; }
        public double TemperatureDesired { get; set; }
        public DateTime MeasurementDate { get; set; }

    }
}
