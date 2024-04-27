using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface ICropRepository
    {
        Task<IEnumerable<Crop>> GetCrops();
        Task<Crop?> GetCrop(int id);
        Task<Crop> CreateCrop(Crop crop);
        Task<Crop> UpdateCrop(Crop crop);
        Task<Crop?> DeleteCrop(int id);
    }
    public class CropRepository(ApplicationDbContext db): ICropRepository
    {
        // Obtenemos todos los cultivos
        public async Task<IEnumerable<Crop>> GetCrops()
        {
            return await db.Crop.ToListAsync();
        }

        // Obtenemos un cultivo por su id
        public async Task<Crop?> GetCrop(int id)
        {
            return await db.Crop.FindAsync(id);
        }

        // Creamos un cultivo

        public async Task<Crop> CreateCrop(Crop crop)
        {
            db.Crop.Add(crop);
            await db.SaveChangesAsync();
            return crop;
        }

        // Actualizamos un cultivo

        public async Task<Crop> UpdateCrop(Crop crop)
        {
            db.Entry(crop).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return crop;
        }

        // Eliminamos un cultivo

        public async Task<Crop?> DeleteCrop(int id)
        {
            Crop? crop = await db.Crop.FindAsync(id);
            if (crop == null) return null;
            crop.IsDeleted = false;
            db.Entry(crop).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return crop;
        }
    }
}
