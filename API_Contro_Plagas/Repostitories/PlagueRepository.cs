using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface IPlagueRepository
    {
        Task<IEnumerable<Plague>> GetPlagues();
        Task<Plague?> GetPlague(int id);
        Task<Plague> CreatePlague(Plague plague);
        Task<Plague> UpdatePlague(Plague plague);
        Task<Plague?> DeletePlague(int id);

    }
    public class PlagueRepository(ApplicationDbContext db) : IPlagueRepository
    {
        // Obtenemos todas las plagas
        public async Task<IEnumerable<Plague>> GetPlagues()
        {
            return await db.Plague.ToListAsync();
        }

        // Obtenemos una plaga por su id
        public async Task<Plague?> GetPlague(int id)
        {
            return await db.Plague.FindAsync(id);
        }

        // Creamos una plaga
        public async Task<Plague> CreatePlague(Plague plague)
        {
            db.Plague.Add(plague);
            await db.SaveChangesAsync();
            return plague;
        }

        // Actualizamos una plaga
        public async Task<Plague> UpdatePlague(Plague plague)
        {
            db.Entry(plague).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return plague;
        }

        // Eliminamos una plaga
        public async Task<Plague?> DeletePlague(int id)
        {
            Plague? plague = await db.Plague.FindAsync(id);
            if (plague == null) return null;
            plague.IsDeleted = false;
            db.Entry(plague).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return plague;
        }
    }
}
