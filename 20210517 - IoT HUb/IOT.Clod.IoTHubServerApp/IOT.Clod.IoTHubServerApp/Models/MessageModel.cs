namespace IOT.Clod.IoTHubServerApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MessageModel
    {
        [Required]
        public string TargetDevice { get; set; }
        [Required]
        public string MessageText { get; set; }

    }
}
