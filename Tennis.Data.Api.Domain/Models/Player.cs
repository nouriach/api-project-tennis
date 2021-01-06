using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Tennis.Data.Api.Domain.Models
{
    public class Player
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Properties
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        // Foreign Key

        // Navigatonal Key 
        public Skill Skill { get; set; }
        public Style Style { get; set; }
    }
    public class Skill
    {
        public int Speed { get; set; }
        public int Serve { get; set; }
        public int Power { get; set; }
        public int Technique { get; set; }
        public int Endurance { get; set; }
        public int Flair { get; set; }
    }

    public class Style
    {
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
    }
}
