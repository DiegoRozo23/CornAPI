using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface IEvolutionCropService
    {
        Task<IEnumerable<EvolutionCrop>> GetEvolutionCrops();
        Task<EvolutionCrop?> GetEvolutionCrop(int id);
        Task<EvolutionCrop> CreateEvolutionCrop(
            DateTime Record,
            string Observation,
            int IdCrop
         );
        Task<EvolutionCrop> UpdateEvolutionCrop(
            int IdEvolutionCrop,
            DateTime? Record,
            string? Observation,
            int? IdCrop
         );
        Task<EvolutionCrop?> DeleteEvolutionCrop(int id);
    }
    public class EvolutionCropService(IEvolutionCropRepository evolutionCropRepository) : IEvolutionCropService
    {
        // Obtenemos todos los cultivos
        public async Task<IEnumerable<EvolutionCrop>> GetEvolutionCrops()
        {
            return await evolutionCropRepository.GetEvolutionCrops();
        }

        // Obtenemos un cultivo por su id

        public async Task<EvolutionCrop?> GetEvolutionCrop(int id)
        {
            return await evolutionCropRepository.GetEvolutionCrop(id);
        }

        // Creamos un cultivo

        public async Task<EvolutionCrop> CreateEvolutionCrop(
           DateTime Record,
           string Observation,
           int IdCrop
         )
        {
            return await evolutionCropRepository.CreateEvolutionCrop(new EvolutionCrop
            {
                Record = Record,
                Observation = Observation,
                IdCrop = IdCrop
            });
        }

        // Actualizamos un cultivo

        public async Task<EvolutionCrop> UpdateEvolutionCrop(
           int IdEvolutionCrop,
           DateTime? Record,
           string? Observation,
           int? IdCrop
        )
        {
            EvolutionCrop? evolutionCrop = await evolutionCropRepository.GetEvolutionCrop(IdEvolutionCrop);
            if (evolutionCrop == null) throw new Exception("No se encontro el cultivo");

            evolutionCrop.Record = Record ?? evolutionCrop.Record;
            evolutionCrop.Observation = Observation ?? evolutionCrop.Observation;
            evolutionCrop.IdCrop = IdCrop ?? evolutionCrop.IdCrop;
            return await evolutionCropRepository.UpdateEvolutionCrop(evolutionCrop);
            
        }

        // Eliminamos un cultivo
        public async Task<EvolutionCrop?> DeleteEvolutionCrop(int id)
        {
            return await evolutionCropRepository.DeleteEvolutionCrop(id);
        }
    }
    
}
