using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface ITypePlagueRepository
    {
        Task<IEnumerable<TypePlague>> GetTypePlagues();
        Task<TypePlague?> GetTypePlague(int id);
        Task<TypePlague> CreateTypePlague(TypePlague typePlague);
        Task<TypePlague> UpdateTypePlague(TypePlague typePlague);
        Task<TypePlague?> DeleteTypePlague(int id);


    }
    public class TypePlagueRepository(ApplicationDbContext db) : ITypePlagueRepository
    {
        // Obtenemos todos los tipos de plagas
        public async Task<IEnumerable<TypePlague>> GetTypePlagues()
        {
            return await db.TypePlague.ToListAsync();
        }

        // Obtenemos un tipo de plaga por su id

        public async Task<TypePlague?> GetTypePlague(int id)
        {
            return await db.TypePlague.FindAsync(id);
        }

        // Creamos un tipo de plaga

        public async Task<TypePlague> CreateTypePlague(TypePlague typePlague)
        {
            db.TypePlague.Add(typePlague);
            await db.SaveChangesAsync();
            return typePlague;
        }

        // Actualizamos un tipo de plaga

        public async Task<TypePlague> UpdateTypePlague(TypePlague typePlague)
        {
            db.Entry(typePlague).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return typePlague;
        }

        // Eliminamos un tipo de plaga

        public async Task<TypePlague?> DeleteTypePlague(int id)
        {
            TypePlague? typePlague = await db.TypePlague.FindAsync(id);
            if (typePlague == null) return null;
            typePlague.IsDeleted = false;
            db.Entry(typePlague).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return typePlague;
        }
    }
}
