using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface IEvolutionCropRepository
    {
        Task<IEnumerable<EvolutionCrop>> GetEvolutionCrops();
        Task<EvolutionCrop?> GetEvolutionCrop(int id);
        Task<EvolutionCrop> CreateEvolutionCrop(EvolutionCrop evolutionCrop);
        Task<EvolutionCrop> UpdateEvolutionCrop(EvolutionCrop evolutionCrop);
        Task<EvolutionCrop?> DeleteEvolutionCrop(int id);
    }

    public class EvolutionCropRepository(ApplicationDbContext db): IEvolutionCropRepository
    {
        // Obtenemos todos los cultivos
        public async Task<IEnumerable<EvolutionCrop>> GetEvolutionCrops()
        {
            return await db.EvolutionCrop.ToListAsync();
        }

        // Obtenemos un cultivo por su id
        public async Task<EvolutionCrop?> GetEvolutionCrop(int id)
        {
            return await db.EvolutionCrop.FindAsync(id);
        }

        // Creamos un cultivo

        public async Task<EvolutionCrop> CreateEvolutionCrop(EvolutionCrop evolutionCrop)
        {
            db.EvolutionCrop.Add(evolutionCrop);
            await db.SaveChangesAsync();
            return evolutionCrop;
        }

        // Actualizamos un cultivo

        public async Task<EvolutionCrop> UpdateEvolutionCrop(EvolutionCrop evolutionCrop)
        {
            db.Entry(evolutionCrop).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return evolutionCrop;
        }

        // Eliminamos un cultivo

        public async Task<EvolutionCrop?> DeleteEvolutionCrop(int id)
        {
            EvolutionCrop? evolutionCrop = await db.EvolutionCrop.FindAsync(id);
            if (evolutionCrop == null) return null;
            evolutionCrop.IsDeleted = false;
            db.Entry(evolutionCrop).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return evolutionCrop;
        }
    }
}
