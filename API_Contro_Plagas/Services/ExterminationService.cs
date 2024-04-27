using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface IExterminationService
    {
        Task<IEnumerable<Extermination>> GetExterminations();
        Task<Extermination?> GetExtermination(int id);
        Task<Extermination> CreateExtermination(
            DateTime Record,
            int IdCrop,
            int IdPlague,
            int IdPesticide,
            string? Observation
        );
        Task<Extermination> UpdateExtermination(
            
            int IdExtermination,
            DateTime? Record,
            int? IdCrop,
            int? IdPlague,
            int? IdPesticide,
            string? Observation
        );
        Task<Extermination?> DeleteExtermination(int id);
    }
    public class ExterminationService (IExterminationRepository exterminationRepository): IExterminationService
    {

        // Obtenemos todas las exterminaciones
        public async Task<IEnumerable<Extermination>> GetExterminations()
        {
            return await exterminationRepository.GetExterminations();
        }

        // Obtenemos una exterminacion por su id
        public async Task<Extermination?> GetExtermination(int id)
        {
            return await exterminationRepository.GetExtermination(id);
        }

        // Creamos una exterminacion
        public async Task<Extermination> CreateExtermination(
            DateTime Record,
            int IdCrop,
            int IdPlague,
            int IdPesticide,
            string? Observation
        )
        {
            return await exterminationRepository.CreateExtermination(new Extermination
            {
                Record = Record,
                IdCrop = IdCrop,
                IdPlague = IdPlague,
                IdPesticide = IdPesticide,
                Observation = Observation
            });
        }

        // Actualizamos una exterminacion
        public async Task<Extermination> UpdateExtermination(
            int IdExtermination,
            DateTime? Record,
            int? IdCrop,
            int? IdPlague,
            int? IdPesticide,
            string? Observation
         )
        {
            Extermination? extermination = await exterminationRepository.GetExtermination(IdExtermination);
            if (extermination == null) throw new Exception("Extermination not found");
            extermination.Record = Record ?? extermination.Record;
            extermination.IdCrop = IdCrop ?? extermination.IdCrop;
            extermination.IdPlague = IdPlague ?? extermination.IdPlague;
            extermination.IdPesticide = IdPesticide ?? extermination.IdPesticide;
            extermination.Observation = Observation ?? extermination.Observation;
            return await exterminationRepository.UpdateExtermination(extermination);
        }

        // Eliminamos una exterminacion

        public async Task<Extermination?> DeleteExtermination(int id)
        {
            return await exterminationRepository.DeleteExtermination(id);
        }

    }
}
