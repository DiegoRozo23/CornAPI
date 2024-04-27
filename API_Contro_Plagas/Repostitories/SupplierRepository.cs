using API_Contro_Plagas.Context;
using API_Contro_Plagas.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Contro_Plagas.Repostitories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliers();
        Task<Supplier?> GetSupplier(int id);
        Task<Supplier> CreateSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(Supplier supplier);
        Task<Supplier?> DeleteSupplier(int id);

    }
    public class SupplierRepository(ApplicationDbContext db) : ISupplierRepository
    {
        // Obtenemos todos los proveedores
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await db.Supplier.ToListAsync();
        }

        // Obtenemos un proveedor por su id

        public async Task<Supplier?> GetSupplier(int id)
        {
            return await db.Supplier.FindAsync(id);
        }

        // Creamos un proveedor

        public async Task<Supplier> CreateSupplier(Supplier supplier)
        {
            db.Supplier.Add(supplier);
            await db.SaveChangesAsync();
            return supplier;
        }

        // Actualizamos un proveedor

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return supplier;
        }

        // Eliminamos un proveedor

        public async Task<Supplier?> DeleteSupplier(int id)
        {
            Supplier? supplier = await db.Supplier.FindAsync(id);
            if (supplier == null) return null;
            supplier.IsDeleted = false;
            db.Entry(supplier).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return supplier;
        }

    }
}
