using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TypeCropController(ITypeCropService typeCropService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeCrop>>> GetTypeCrops()
        {
            IEnumerable<TypeCrop> typeCrops = await typeCropService.GetTypeCrops();
            return Ok(typeCrops);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypeCrop>> GetTypeCrop(int id)
        {
            TypeCrop? typeCrop = await typeCropService.GetTypeCrop(id);
            if (typeCrop == null) return NotFound();
            return Ok(typeCrop);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeCrop(
          string TypeCropName
        )
        {
            var typeCrop = await typeCropService.CreateTypeCrop(TypeCropName);
            return CreatedAtAction(nameof(GetTypeCrop), new { id = typeCrop.IdTypeCrop }, typeCrop);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTypeCrop(
          int IdTypeCrop,
          string? TypeCropName
        )
        {
            var updaptedTypeCrop = await typeCropService.UpdateTypeCrop(IdTypeCrop, TypeCropName);
            return Ok(updaptedTypeCrop);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeCrop(int id)
        {
            var typeCrop = await typeCropService.DeleteTypeCrop(id);
            if (typeCrop == null) return NotFound();
            return Ok(typeCrop);
        }
    }
}
