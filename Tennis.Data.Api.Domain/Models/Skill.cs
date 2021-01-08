using System.ComponentModel.DataAnnotations;

namespace Tennis.Data.Api.Domain.Models
{
    public class Skill
    {
        // Primary Key
        // Properties
        public int Speed { get; set; }
        public int Serve { get; set; }
        public int Power { get; set; }
        public int Technique { get; set; }
        public int Endurance { get; set; }
        public int Flair { get; set; }
        // Foreign Key
        [Key]
        public int PlayerId { get; set; }

        // Navigational Property
    }
}
