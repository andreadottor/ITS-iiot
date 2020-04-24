using Newtonsoft.Json;

namespace Dottor.Earthquake.Models
{
    class EarthquakeProperties
    {
        [JsonProperty("place")]
        public string Place { get; set; }
    }
}
