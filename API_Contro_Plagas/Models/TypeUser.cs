using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class TypeUser{
        [Key]
        public int IdTypeUser { get; set; }
        public required string TypeUserName { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;
    }
}
