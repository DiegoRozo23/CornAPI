using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Contro_Plagas.Models
{
    public class TypeCrop{
        [Key]
        public int IdTypeCrop { get; set; }
        
        public required string TypeCropName { get; set; }


        [JsonIgnore]
        public bool IsDeleted { get; set; } = true;

    }
}

