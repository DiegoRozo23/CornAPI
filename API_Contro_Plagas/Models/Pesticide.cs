using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class Pesticide{
        [Key]
        public int IdPesticide { get; set; }
        public required string PesticideName { get; set; }
        public required string Quality { get; set; }

        //Llave Foranea de los Proveedores
        [ForeignKey(nameof(Supplier))]
        public int IdSupplier { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

        public virtual Supplier? Supplier { get; set; }
    }
}



