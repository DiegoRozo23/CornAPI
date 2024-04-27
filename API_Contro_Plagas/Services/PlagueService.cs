using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface IPlagueService
    {
        Task<IEnumerable<Plague>> GetPlagues();
        Task<Plague?> GetPlague(int id);
        Task<Plague> CreatePlague(
            string PlagueName,
            int IdTypePlague
        );
        Task<Plague> UpdatePlague(
            int IdPlague,
            string? PlagueName,
            int? IdTypePlague
         );
        Task<Plague?> DeletePlague(int id);

    }
    public class PlagueService(IPlagueRepository plagueRepository) : IPlagueService
    {

        // Obtenemos todas las plagas
        public async Task<IEnumerable<Plague>> GetPlagues()
        {
            return await plagueRepository.GetPlagues();
        }

        // Obtenemos una plaga por su id
        public async Task<Plague?> GetPlague(int id)
        {
            return await plagueRepository.GetPlague(id);
        }

        // Creamos una plaga

        public async Task<Plague> CreatePlague(
           string PlagueName,
           int IdTypePlague
        )
        {
           return await plagueRepository.CreatePlague(new Plague
           {
               PlagueName = PlagueName,
               IdTypePlague = IdTypePlague
           });
        }

        // Actualizamos una plaga
        public async Task<Plague> UpdatePlague(
           int IdPlague,
           string? PlagueName,
           int? IdTypePlague
         )
        {
            Plague? plague = await plagueRepository.GetPlague(IdPlague);
            if (plague == null) throw new Exception("Plague not found");
            plague.PlagueName = PlagueName ?? plague.PlagueName;
            plague.IdTypePlague = IdTypePlague ?? plague.IdTypePlague;
            return await plagueRepository.UpdatePlague(plague);
        }

        // Eliminamos una plaga
        public async Task<Plague?> DeletePlague(int id)
        {
            return await plagueRepository.DeletePlague(id);
        }
    }
}
