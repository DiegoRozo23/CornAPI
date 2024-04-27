using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface IPesticideService
    {
        Task<IEnumerable<Pesticide>> GetPesticides();
        Task<Pesticide?> GetPesticide(int id);
        Task<Pesticide> CreatePesticide(
            string PesticideName,
            string Quality,
            int IdSupplier
        );
        Task<Pesticide> UpdatePesticide(
            int IdPesticide,
            string? PesticideName,
            string? Quality,
            int? IdSupplier
        );
        Task<Pesticide?> DeletePesticide(int id);

    }
    public class PesticideService(IPesticideRepository pesticideRepository) : IPesticideService
    {

        // Obtenemos todos los pesticidas

        public async Task<IEnumerable<Pesticide>> GetPesticides()
        {
            return await pesticideRepository.GetPesticides();
        }

        // Obtenemos un pesticida por su id

        public async Task<Pesticide?> GetPesticide(int id)
        {
            return await pesticideRepository.GetPesticide(id);
        }

        // Creamos un pesticida

        
        public async Task<Pesticide> CreatePesticide(
            string PesticideName,
            string Quality,
            int IdSupplier
        )
        {
            return await pesticideRepository.CreatePesticide(new Pesticide
            {
                PesticideName = PesticideName,
                Quality = Quality,
                IdSupplier = IdSupplier
            });
        }

        // Actualizamos un pesticida
        public async Task<Pesticide> UpdatePesticide(
            int IdPesticide,
            string? PesticideName,
            string? Quality,
            int? IdSupplier
         )
        {
            Pesticide? pesticide = await pesticideRepository.GetPesticide(IdPesticide);
            if (pesticide == null) throw new Exception("Pesticide not found");
            pesticide.PesticideName = PesticideName ?? pesticide.PesticideName;
            pesticide.Quality = Quality ?? pesticide.Quality;
            pesticide.IdSupplier = IdSupplier ?? pesticide.IdSupplier;
            return await pesticideRepository.UpdatePesticide(pesticide);
        }

        // Eliminamos un pesticida
        public async Task<Pesticide?> DeletePesticide(int id)
        {
            return await pesticideRepository.DeletePesticide(id);
        }

        
    }
   
}
