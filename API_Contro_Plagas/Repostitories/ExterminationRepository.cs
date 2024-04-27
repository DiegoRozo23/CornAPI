using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface IExterminationRepository
    {
        Task<IEnumerable<Extermination>> GetExterminations();
        Task<Extermination?> GetExtermination(int id);
        Task<Extermination> CreateExtermination(Extermination extermination);
        Task<Extermination> UpdateExtermination(Extermination extermination);
        Task<Extermination?> DeleteExtermination(int id);

    }
    public class ExterminationRepository(ApplicationDbContext db): IExterminationRepository
    {
        public async Task<IEnumerable<Extermination>> GetExterminations()
        {
            return await db.Extermination.ToListAsync();
        }

        public async Task<Extermination?> GetExtermination(int id)
        {
            return await db.Extermination.FindAsync(id);
        }

        public async Task<Extermination> CreateExtermination(Extermination extermination)
        {
            db.Extermination.Add(extermination);
            await db.SaveChangesAsync();
            return extermination;
        }

        public async Task<Extermination> UpdateExtermination(Extermination extermination)
        {
            db.Entry(extermination).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return extermination;
        }

        public async Task<Extermination?> DeleteExtermination(int id)
        {
            Extermination? extermination = await db.Extermination.FindAsync(id);
            if (extermination == null) return null;
            extermination.IsDeleted = false;
            db.Entry(extermination).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return extermination;
        }
    }
}
