using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface ITypeCropService
    {
        Task<IEnumerable<TypeCrop>> GetTypeCrops();
        Task<TypeCrop?> GetTypeCrop(int id);
        Task<TypeCrop> CreateTypeCrop 
        (
           string TypeCropName
        );
        Task<TypeCrop> UpdateTypeCrop(
            int IdTypeCrop,
            string? TypeCropName
        );

        Task<TypeCrop?> DeleteTypeCrop(int id);
    }
    public class TypeCropService(ITypeCropRepository typeCropRepository): ITypeCropService
    {
        // Obtenemos todos los tipos de cultivo
        public async Task<IEnumerable<TypeCrop>> GetTypeCrops()
        {
            return await typeCropRepository.GetTypeCrops();
        }


        // Obtenemos un tipo de cultivo por su id

        public async Task<TypeCrop?> GetTypeCrop(int id)
        {
            return await typeCropRepository.GetTypeCrop(id);
        }

        // Creamos un tipo de cultivo

        public async Task<TypeCrop> CreateTypeCrop(
            string TypeCropName
        )
        {
           return await typeCropRepository.CreateTypeCrop(new TypeCrop
           {
               TypeCropName = TypeCropName
           });
        }

        // Actualizamos un tipo de cultivo

        public async Task<TypeCrop> UpdateTypeCrop(
            int IdTypeCrop, 
            string? TypeCropName
        )
        {
            TypeCrop? typeCrop = await typeCropRepository.GetTypeCrop(IdTypeCrop);
            if (typeCrop == null) throw new Exception("TypeCrop not found");
            typeCrop.TypeCropName = TypeCropName ?? typeCrop.TypeCropName;
            return await typeCropRepository.UpdateTypeCrop(typeCrop);
        }

        public async Task<TypeCrop?> DeleteTypeCrop(int id)
        {
            return await typeCropRepository.DeleteTypeCrop(id);
        }
    }
}
