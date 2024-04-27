using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{

    public interface ITypeUserRepository
    {
        Task<IEnumerable<TypeUser>> GetTypeUsers();
        Task<TypeUser?> GetTypeUser(int id);
        Task<TypeUser> CreateTypeUser(TypeUser typeUser);
        Task<TypeUser> UpdateTypeUser(TypeUser typeUser);
        Task<TypeUser?> DeleteTypeUser(int id);

    }
    public class TypeUserRepository(ApplicationDbContext db) : ITypeUserRepository
    {
        // Obtenemos todos los tipos de usuario
        public async Task<IEnumerable<TypeUser>> GetTypeUsers()
        {
            return await db.TypeUser.ToListAsync();
        }

        // Obtenemos un tipo de usuario por su id

        public async Task<TypeUser?> GetTypeUser(int id)
        {
            return await db.TypeUser.FindAsync(id);
        }

        // Creamos un tipo de usuario

        public async Task<TypeUser> CreateTypeUser(TypeUser typeUser)
        {
            db.TypeUser.Add(typeUser);
            await db.SaveChangesAsync();
            return typeUser;
        }

        // Actualizamos un tipo de usuario

        public async Task<TypeUser> UpdateTypeUser(TypeUser typeUser)
        {
            db.Entry(typeUser).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return typeUser;
        }

        // Eliminamos un tipo de usuario

        public async Task<TypeUser?> DeleteTypeUser(int id)
        {
            TypeUser? typeUser = await db.TypeUser.FindAsync(id);
            if (typeUser == null) return null;
            typeUser.IsDeleted = false;
            db.Entry(typeUser).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return typeUser;
        }
    }
}
