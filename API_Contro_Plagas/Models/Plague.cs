using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class Plague{
        [Key]
        public int IdPlague { get; set; }
        public required string PlagueName { get; set; }

        //Llave Foranea
        [ForeignKey(nameof(TypePlague))]
        public int IdTypePlague { get; set; }


        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual TypePlague? TypePlague { get; set; }

    }
}

