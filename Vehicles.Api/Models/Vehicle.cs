using System.Text.Json.Serialization;

namespace Vehicles.Api.Models
{
    public class Vehicle
    {
        [JsonPropertyName("make")]
        public string Make { get; set; }
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("trim")]
        public string Trim { get; set; }
        [JsonPropertyName("colour")]
        public string Colour { get; set; }
    }
}
