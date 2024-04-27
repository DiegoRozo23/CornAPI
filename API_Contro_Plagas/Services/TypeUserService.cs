using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface    ITypeUserService
    {
        Task<IEnumerable<TypeUser>> GetTypeUsers();
        Task<TypeUser?> GetTypeUser(int id);
        Task<TypeUser> CreateTypeUser(
            string TypeUserName
        );

        Task<TypeUser> UpdateTypeUser(
           int IdUserType,
           string TypeUserName
        );
        Task<TypeUser?> DeleteTypeUser(int id);

    }
    public class TypeUserService(ITypeUserRepository typeUserRepository): ITypeUserService
    {
        // Obtenemos todos los tipos de usuario
        public async Task<IEnumerable<TypeUser>> GetTypeUsers()
        {
            return await typeUserRepository.GetTypeUsers();
        }

        // Obtenemos un tipo de usuario por su id

        public async Task<TypeUser?> GetTypeUser(int id)
        {
            return await typeUserRepository.GetTypeUser(id);
        }


        // Creamos un tipo de usuario
        public async Task<TypeUser> CreateTypeUser(
            string TypeUserName
        )
        {
            
            return await typeUserRepository.CreateTypeUser(new TypeUser
            { 
                TypeUserName = TypeUserName
            });
        }

        // Actualizamos un tipo de usuario

        public async Task<TypeUser> UpdateTypeUser(
            int IdUserType, 
            string? TypeUserName
        )
        {
           TypeUser? typeUser = await typeUserRepository.GetTypeUser(IdUserType);
            if (typeUser == null) throw new Exception("TypeUser not found");
            typeUser.TypeUserName = TypeUserName ?? typeUser.TypeUserName;
            return await typeUserRepository.UpdateTypeUser(typeUser);
        }

        public async Task<TypeUser?> DeleteTypeUser(int id)
        {
            return await typeUserRepository.DeleteTypeUser(id);
        }
    }
}
