using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class TypePlague{
        [Key]
        public int IdTypePlague { get; set; }
        
        public required string TypePlagueName { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;
    }
}
