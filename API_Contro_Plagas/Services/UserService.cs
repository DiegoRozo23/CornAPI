using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> CreateUser(
            string UserName,
            string UserLastname,
            string UserEmail,
            int IdTypeUser
        );

        Task<User> UpdateUser(
            int IdUser,
            string? UserName,
            string? UserLastname,
            string? UserEmail,
            int? IdTypeUser
         );
        Task<User?> DeleteUser(int id);

    }

    public class UserService(IUserRepository userRepository) : IUserService
    {

        // Obtenemos todos los usuarios
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        // Obtenemos un usuario por su id

        public async Task<User?> GetUser(int id)
        {
            return await userRepository.GetUser(id);
        }

        // Creamos un usuario

        public async Task<User> CreateUser(
           string UserName,
           string UserLastname,
           string UserEmail,
           int IdTypeUser
         )
        {
            User user = new User
            {
                UserName = UserName,
                UserLastname = UserLastname,
                UserEmail = UserEmail,
                IdTypeUser = IdTypeUser
            };
            return await userRepository.CreateUser(user);
        }


        // Actualizamos un usuario

        public async Task<User> UpdateUser(
          int IdUser,
          string? UserName,
          string? UserLastname,
          string? UserEmail,
          int? IdTypeUser
        )
        {
            User? user = await userRepository.GetUser(IdUser);
            if (user == null) throw new Exception("User not found");
            user.UserName = UserName ?? user.UserName;
            user.UserLastname = UserLastname ?? user.UserLastname;
            user.UserEmail = UserEmail ?? user.UserEmail;
            user.IdTypeUser = IdTypeUser ?? user.IdTypeUser;
            return await userRepository.UpdateUser(user);
        }

        // Eliminamos un usuario

        public async Task<User?> DeleteUser(int id)
        {
            return await userRepository.DeleteUser(id);
        }
    }
}
