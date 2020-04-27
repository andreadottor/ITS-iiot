using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.WorkerServiceDemo.Models
{
    class Activity
    {
        [JsonProperty("activity")]
        public string Title { get; set; }

        [JsonProperty("accessibility")]
        public double? Accessibility { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("participants")]
        public int Participants { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
