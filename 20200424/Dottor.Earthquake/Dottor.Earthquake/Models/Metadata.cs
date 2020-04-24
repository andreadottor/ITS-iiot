using Newtonsoft.Json;


namespace Dottor.Earthquake.Models
{
    class Metadata
    {
        [JsonProperty("generated")]
        public long Generated { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("status")]
        public int Status { get; set; }
        
        [JsonProperty("api")]
        public string Api { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
