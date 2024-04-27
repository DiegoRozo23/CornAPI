using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{   
    // Cultivo
    public class Crop {

        [Key]
        public int IdCrop { get; set; }

        //Llave Foranea del Usuario
        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }

        //Llave Foranea del Tipo de Cultivo
        [ForeignKey(nameof(TypeCrop))]
        public int IdTypeCrop { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual User? User { get; set; }
        public virtual TypeCrop? TypeCrop { get; set; }

    }
}

