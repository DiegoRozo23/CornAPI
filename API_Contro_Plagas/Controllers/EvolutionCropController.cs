using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EvolutionCropController(IEvolutionCropService evolutionCropService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvolutionCrop>>> GetEvolutionCrops()
        {
            IEnumerable<EvolutionCrop> evolutionCrops = await evolutionCropService.GetEvolutionCrops();
            return Ok(evolutionCrops);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EvolutionCrop>> GetEvolutionCrop(int id)
        {
            EvolutionCrop? evolutionCrop = await evolutionCropService.GetEvolutionCrop(id);
            if (evolutionCrop == null) return NotFound();
            return Ok(evolutionCrop);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvolutionCrop(
           DateTime Record,
           string Observation,
           int IdCrop
        )
        {
           var evolutionCrop = await evolutionCropService.CreateEvolutionCrop(Record, Observation, IdCrop);
            return CreatedAtAction(nameof(GetEvolutionCrop), new { id = evolutionCrop.IdEvolutionCrop }, evolutionCrop);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvolutionCrop(
           int IdEvolutionCrop,
           DateTime? Record,
           string? Observation,
           int? IdCrop
        )
        {
            var updaptedEvolutionCrop = await evolutionCropService.UpdateEvolutionCrop(IdEvolutionCrop, Record, Observation, IdCrop);
            return Ok(updaptedEvolutionCrop);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvolutionCrop(int id)
        {
            var evolutionCrop = await evolutionCropService.DeleteEvolutionCrop(id);
            if (evolutionCrop == null) return NotFound();
            return Ok(evolutionCrop);
        }
    }
}
