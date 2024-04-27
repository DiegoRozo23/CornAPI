using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController(ISupplierService supplierService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            IEnumerable<Supplier> suppliers = await supplierService.GetSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            Supplier? supplier = await supplierService.GetSupplier(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }

        [HttpPost]

        public async Task<IActionResult> CreateSupplier(
           string SupplierName,
           string SupplierAddress,
           string SupplierPhone
        )
        {
            var supplier = await supplierService.CreateSupplier(SupplierName, SupplierAddress, SupplierPhone);
            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.IdSupplier }, supplier);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateSupplier(
           int IdSupplier,
           string? SupplierName,
           string? SupplierAddress,
           string? SupplierPhone
        )
        {
            var updaptedSupplier = await supplierService.UpdateSupplier(IdSupplier, SupplierName, SupplierAddress, SupplierPhone);
            return Ok(updaptedSupplier);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await supplierService.DeleteSupplier(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }
    }
}
