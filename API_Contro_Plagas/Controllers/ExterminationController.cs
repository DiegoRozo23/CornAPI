using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ExterminationController(IExterminationService exterminationService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extermination>>> GetExterminations()
        {
            IEnumerable<Extermination> exterminations = await exterminationService.GetExterminations();
            return Ok(exterminations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Extermination>> GetExtermination(int id)
        {
            Extermination? extermination = await exterminationService.GetExtermination(id);
            if (extermination == null) return NotFound();
            return Ok(extermination);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExtermination(
            DateTime Record,
            int IdCrop,
            int IdPlague,
            int IdPesticide,
            string? Observation
        )
        {
            var extermination = await exterminationService.CreateExtermination(Record, IdCrop, IdPlague, IdPesticide, Observation);
            return CreatedAtAction(nameof(GetExtermination), new { id = extermination.IdExtermination }, extermination);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExtermination(
           int IdExtermination,
           DateTime? Record,
           int? IdCrop,
           int? IdPlague,
           int? IdPesticide,
           string? Observation
        )
        {
            var updaptedExtermination = await exterminationService.UpdateExtermination(IdExtermination, Record, IdCrop, IdPlague, IdPesticide, Observation);
            return Ok(updaptedExtermination);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExtermination(int id)
        {
            var extermination = await exterminationService.DeleteExtermination(id);
            if (extermination == null) return NotFound();
            return Ok(extermination);
        }
    }
}
