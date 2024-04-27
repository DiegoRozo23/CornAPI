using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
    }
    public class UserRepository(ApplicationDbContext db) : IUserRepository
    {

        // Obtenemos todos los usuarios
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.User.ToListAsync();
        }

        // Obtenemos un usuario por su id

        public async Task<User?> GetUser(int id)
        {
            return await db.User.FindAsync(id);
        }

        // Creamos un usuario

        public async Task<User> CreateUser(User user)
        {
            db.User.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        // Actualizamos un usuario

        public async Task<User> UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return user;
        }

        // Eliminamos un usuario

        public async Task<User?> DeleteUser(int id)
        {
            User? user = await db.User.FindAsync(id);
            if (user == null) return null;
            user.IsDeleted = false;
            db.Entry(user).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return user;
        }

    }
}
