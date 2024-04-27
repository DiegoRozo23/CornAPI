using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class Extermination
    {
        [Key]
        public int IdExtermination { get; set; }

        [Required]
        public DateTime Record { get; set; }

        // Llave Foranea de los Cultivos
        [ForeignKey(nameof(Crop))]
        public int IdCrop { get; set; }

        // Llave Foranea de las plagas
        [ForeignKey(nameof(Plague))]
        public int IdPlague { get; set; }

        // Llave Foranea de los pesticidas
        [ForeignKey(nameof(Pesticide))]
        public int IdPesticide { get; set; }
        public string? Observation { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;


        public virtual Crop? Crop { get; set; }
        public virtual Plague? Plague { get; set; }
        public virtual Pesticide? Pesticide { get; set; }
    }

}


