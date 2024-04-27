using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface ICropService
    {
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop?> GetCrop(int id);
        Task<Crop> CreateCrop(
            int IdUser, 
            int IdTypeCrop
        );
        Task<Crop> UpdateCrop(
            int IdCrop,
            int? IdUser,
            int? IdTypeCrop
        );
        Task<Crop?> DeleteCrop(int id);
    }

    public class CropService(ICropRepository cropRepository) : ICropService
    {

        // Obtenemos todos los cultivos
        public async Task<IEnumerable<Crop>> GetCrops()
        {
            return await cropRepository.GetCrops();
        }

        // Obtenemos un cultivo por su id
        public async Task<Crop?> GetCrop(int id)
        {
            return await cropRepository.GetCrop(id);
        }

        // Creamos un cultivo
        public async Task<Crop> CreateCrop(
           int IdUser, 
           int IdTypeCrop
        )
        {
            return await cropRepository.CreateCrop(new Crop
                               {
                    IdUser = IdUser,
                    IdTypeCrop = IdTypeCrop
            });
        }

        // Actualizamos un cultivo
        
        public async Task<Crop> UpdateCrop(
           int IdCrop,
           int? IdUser,
           int? IdTypeCrop
         )
        {
            Crop? crop = await cropRepository.GetCrop(IdCrop);
            if (crop == null) throw new Exception("Crop not found");
            crop.IdUser = IdUser ?? crop.IdUser;
            crop.IdTypeCrop = IdTypeCrop ?? crop.IdTypeCrop;
            return await cropRepository.UpdateCrop(crop);
        }

        // Eliminamos un cultivo
        public async Task<Crop?> DeleteCrop(int id)
        {
            return await cropRepository.DeleteCrop(id);
        }
    }
}
