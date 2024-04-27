using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface IPesticideRepository
    {
        Task<IEnumerable<Pesticide>> GetPesticides();
        Task<Pesticide?> GetPesticide(int id);
        Task<Pesticide> CreatePesticide(Pesticide pesticide);
        Task<Pesticide> UpdatePesticide(Pesticide pesticide);
        Task<Pesticide?> DeletePesticide(int id);
    }
    public class PesticideRepository(ApplicationDbContext db) : IPesticideRepository
    {
        // Obtenemos todos los pesticidas
        public async Task<IEnumerable<Pesticide>> GetPesticides()
        {
            return await db.Pesticide.ToListAsync();
        }

        // Obtenemos un pesticida por su id

        public async Task<Pesticide?> GetPesticide(int id)
        {
            return await db.Pesticide.FindAsync(id);
        }

        // Creamos un pesticida

        public async Task<Pesticide> CreatePesticide(Pesticide pesticide)
        {
            db.Pesticide.Add(pesticide);
            await db.SaveChangesAsync();
            return pesticide;
        }

        // Actualizamos un pesticida

        public async Task<Pesticide> UpdatePesticide(Pesticide pesticide)
        {
            db.Entry(pesticide).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return pesticide;
        }


        // Eliminamos un pesticida

        public async Task<Pesticide?> DeletePesticide(int id)
        {
            Pesticide? pesticide = await db.Pesticide.FindAsync(id);
            if (pesticide == null) return null;
            pesticide.IsDeleted = false;
            db.Entry(pesticide).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return pesticide;
        }
    }
}
