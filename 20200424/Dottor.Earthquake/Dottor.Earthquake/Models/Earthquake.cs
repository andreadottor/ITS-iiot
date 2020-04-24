using Newtonsoft.Json;

namespace Dottor.Earthquake.Models
{
    class Earthquake
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("properties")]
        public EarthquakeProperties Properties { get; set; }

    }
}
