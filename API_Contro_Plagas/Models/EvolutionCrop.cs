    using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class EvolutionCrop{
        [Key]
        public int IdEvolutionCrop { get; set; }
        public required DateTime Record { get; set; }
        public required string Observation { get; set; }

        //Llave Foranea
        [ForeignKey(nameof(Crop))]
        public required int IdCrop { get; set; }
        

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual Crop? Crop { get; set; }

    }
}

