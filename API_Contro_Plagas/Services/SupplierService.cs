using API_Contro_Plagas.Models;
using API_Contro_Plagas.Repostitories;

namespace API_Contro_Plagas.Services
{

    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetSuppliers();
        Task<Supplier?> GetSupplier(int id);
        Task<Supplier> CreateSupplier(
           string SupplierName,
           string SupplierAddress,
           string SuppplierPhone
        );
        Task<Supplier> UpdateSupplier(
           int IdSupplier,
           string? SupplierName,
           string? SupplierAddress,
           string? SuppplierPhone
        );
        Task<Supplier?> DeleteSupplier(int id);
    }

    public class SupplierService(ISupplierRepository supplierRepository): ISupplierService
    {

        // Obtenemos todos los proveedores
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await supplierRepository.GetSuppliers();
        }

        // Obtenemos un proveedor por su id

        public async Task<Supplier?> GetSupplier(int id)
        {
            return await supplierRepository.GetSupplier(id);
        }

        // Creamos un proveedor
        public async Task<Supplier> CreateSupplier(
           string SupplierName,
           string SupplierAddress,
           string SuppplierPhone
        )
        {
            return await supplierRepository.CreateSupplier(new Supplier
            {
                SupplierName = SupplierName,
                SupplierAddress = SupplierAddress,
                SuppplierPhone = SuppplierPhone
            });
        }
            
        // Actualizamos un proveedor

        public async Task<Supplier> UpdateSupplier(
           int IdSupplier,
           string? SupplierName,
           string? SupplierAddress,
           string? SuppplierPhone
        )
        {
            Supplier? supplier = await supplierRepository.GetSupplier(IdSupplier);
            if (supplier == null) throw new Exception("Supplier not found");
            supplier.SupplierName = SupplierName ?? supplier.SupplierName;
            supplier.SupplierAddress = SupplierAddress ?? supplier.SupplierAddress;
            supplier.SuppplierPhone = SuppplierPhone ?? supplier.SuppplierPhone;
           return await supplierRepository.UpdateSupplier(supplier);
        }

        // Eliminamos un proveedor
        public async Task<Supplier?> DeleteSupplier(int id)
        {
            return await supplierRepository.DeleteSupplier(id);
        }
    }
}
