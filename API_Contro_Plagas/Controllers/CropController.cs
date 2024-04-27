using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class CropController(ICropService cropService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crop>>> GetCrops()
        {
            IEnumerable<Crop> crops = await cropService.GetCrops();
            return Ok(crops);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Crop>> GetCrop(int id)
        {
            Crop? crop = await cropService.GetCrop(id);
            if (crop == null) return NotFound();
            return Ok(crop);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCrop(
          int IdUser,
           int IdTypeCrop
        )
        {
            var crop = await cropService.CreateCrop(IdUser, IdTypeCrop);
            return CreatedAtAction(nameof(GetCrop), new { id = crop.IdCrop }, crop);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCrop(
          int IdCrop,
          int? IdUser,
          int? IdTypeCrop
                   )
        {
            var updaptedCrop = await cropService.UpdateCrop(IdCrop, IdUser, IdTypeCrop);
            return Ok(updaptedCrop);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrop(int id)
        {
            var crop = await cropService.DeleteCrop(id);
            if (crop == null) return NotFound();
            return Ok(crop);
        }
    }
}
