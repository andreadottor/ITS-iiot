using Newtonsoft.Json;


namespace Dottor.Earthquake.Models
{
    class EarthquakesGeoJsonResponse
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("features")]
        public Earthquake[] Earthquakes { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }


    }
}
