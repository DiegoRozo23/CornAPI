using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class User{
        [Key]
        public int IdUser { get; set; }
        public required string UserName { get; set; }
        public required string UserLastname { get; set; }
        public required string UserEmail { get; set; }

        // Llave foránea
        [ForeignKey(nameof(TypeUser))]
        public int IdTypeUser { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual TypeUser? TypeUser{ get; set; }

    }
}

