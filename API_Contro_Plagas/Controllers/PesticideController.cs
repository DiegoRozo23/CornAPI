using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PesticideController(IPesticideService pesticideService) : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Pesticide>>> GetPesticides()
        {
            IEnumerable<Pesticide> pesticides = await pesticideService.GetPesticides();
            return Ok(pesticides);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pesticide>> GetPesticide(int id)
        {
            Pesticide? pesticide = await pesticideService.GetPesticide(id);
            if (pesticide == null) return NotFound();
            return Ok(pesticide);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePesticide(
            string PesticideName,
            string Quality,
            int IdSupplier
        )
        {

            var pesticide = await pesticideService.CreatePesticide(PesticideName, Quality, IdSupplier);
            return CreatedAtAction(nameof(GetPesticide), new { id = pesticide.IdPesticide }, pesticide);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePesticide(
          int IdPesticide,
          string? PesticideName,
          string? Quality,
          int? IdSupplier
        )
        {
            var updaptedPesticide = await pesticideService.UpdatePesticide(IdPesticide, PesticideName, Quality, IdSupplier);
            return Ok(updaptedPesticide);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePesticide(int id)
        {
            var pesticide = await pesticideService.DeletePesticide(id);
            if (pesticide == null) return NotFound();
            return Ok(pesticide);
        }
    }
}
