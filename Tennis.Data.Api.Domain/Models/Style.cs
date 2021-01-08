using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tennis.Data.Api.Domain.Models
{
    public class Style
    {
        // Primary Key
        // Properties
        [JsonProperty("hard_hitter")]
        public int HardHitter { get; set; }

        [JsonProperty("tactical")]
        public int Tactical { get; set; }

        [JsonProperty("serve_and_volley")]
        public int ServeAndVolley { get; set; }

        [JsonProperty("great_return")]
        public int GreatReturn { get; set; }

        [JsonProperty("rocket_serve")]
        public int RocketServe { get; set; }

        [JsonProperty("solid_defence")]
        public int SolidDefence { get; set; }
        // Foreign Key
        [Key]
        public int PlayerId { get; set; }
        // Navigational Property


    }
}
