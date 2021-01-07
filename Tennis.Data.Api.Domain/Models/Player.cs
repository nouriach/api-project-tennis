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
}
