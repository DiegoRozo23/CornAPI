using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{
    public interface ITypePlagueService
    {
        Task<IEnumerable<TypePlague>> GetTypePlagues();
        Task<TypePlague?> GetTypePlague(int id);
        Task<TypePlague> CreateTypePlague(
         string TypePlagueName
        );
        Task<TypePlague> UpdateTypePlague(
          int IdTypePlague,
          string? TypePlagueName  
        );

        Task<TypePlague?> DeleteTypePlague(int id);

    }
    public class TypePlagueService(ITypePlagueRepository typePlagueRepository): ITypePlagueService
    {
        
        // Obtenemos todos los tipos de plagas
        public async Task<IEnumerable<TypePlague>> GetTypePlagues()
        {
            return await typePlagueRepository.GetTypePlagues();
        }

        // Obtenemos un tipo de plaga por su id

        public async Task<TypePlague?> GetTypePlague(int id)
        {
            return await typePlagueRepository.GetTypePlague(id);
        }

        // Creamos un tipo de plaga

        public async Task<TypePlague> CreateTypePlague(
           string TypePlagueName
        )
        {
            return await typePlagueRepository.CreateTypePlague(new TypePlague
            {
                TypePlagueName = TypePlagueName
            });
        }

        // Actualizamos un tipo de plaga

        public async Task<TypePlague> UpdateTypePlague(
           int IdTypePlague,
           string? TypePlagueName
        )
        {
            TypePlague? typePlague = await typePlagueRepository.GetTypePlague(IdTypePlague);
            if (typePlague == null) throw new Exception("TypePlague not found");
            typePlague.TypePlagueName = TypePlagueName ?? typePlague.TypePlagueName;
            return await typePlagueRepository.UpdateTypePlague(typePlague);
            
        }

        // Eliminamos un tipo de plaga

        public async Task<TypePlague?> DeleteTypePlague(int id)
        {
            return await typePlagueRepository.DeleteTypePlague(id);
        }

    }
}
