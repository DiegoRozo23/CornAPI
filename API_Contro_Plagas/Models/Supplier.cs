using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class Supplier{
        [Key]
        public int IdSupplier { get; set; }

        
        public required string SupplierName { get; set; }
        public required string SupplierAddress { get; set; }
        public required string SuppplierPhone { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;
    }
}

