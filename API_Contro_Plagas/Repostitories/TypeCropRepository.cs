using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface ITypeCropRepository
    {
        Task<IEnumerable<TypeCrop>> GetTypeCrops();
        Task<TypeCrop?> GetTypeCrop(int id);
        Task<TypeCrop> CreateTypeCrop(TypeCrop typeCrop);
        Task<TypeCrop> UpdateTypeCrop(TypeCrop typeCrop);
        Task<TypeCrop?> DeleteTypeCrop(int id);

    }
    public class TypeCropRepository(ApplicationDbContext db) : ITypeCropRepository
    {
        
        // Obtenemos todos los tipos de cultivo
        public async Task<IEnumerable<TypeCrop>> GetTypeCrops()
        {
            return await db.TypeCrop.ToListAsync();
        }

        // Obtenemos un tipo de cultivo por su id

        public async Task<TypeCrop?> GetTypeCrop(int id)
        {
            return await db.TypeCrop.FindAsync(id);
        }

        // Creamos un tipo de cultivo

        public async Task<TypeCrop> CreateTypeCrop(TypeCrop typeCrop)
        {
            db.TypeCrop.Add(typeCrop);
            await db.SaveChangesAsync();
            return typeCrop;
        }

        // Actualizamos un tipo de cultivo

        public async Task<TypeCrop> UpdateTypeCrop(TypeCrop typeCrop)
        {
            db.Entry(typeCrop).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return typeCrop;
        }

        // Eliminamos un tipo de cultivo

        public async Task<TypeCrop?> DeleteTypeCrop(int id)
        {
            TypeCrop? typeCrop = await db.TypeCrop.FindAsync(id);
            if (typeCrop == null) return null;
            typeCrop.IsDeleted = false;
            db.Entry(typeCrop).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return typeCrop;
        }

    }
}
