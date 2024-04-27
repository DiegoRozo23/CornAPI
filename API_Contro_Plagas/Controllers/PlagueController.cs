using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PlagueController(IPlagueService plagueService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plague>>> GetPlagues()
        {
            IEnumerable<Plague> plagues = await plagueService.GetPlagues();
            return Ok(plagues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Plague>> GetPlague(int id)
        {
            Plague? plague = await plagueService.GetPlague(id);
            if (plague == null) return NotFound();
            return Ok(plague);
        }

        [HttpPost]

        public async Task<IActionResult> CreatePlague(
          string PlagueName,
          int IdTypePlague
        )
        {
            var plague = await plagueService.CreatePlague(PlagueName, IdTypePlague);
            return CreatedAtAction(nameof(GetPlague), new { id = plague.IdPlague }, plague);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlague(
           int IdPlague,
           string? PlagueName,
           int? IdTypePlague
        )
        {
            var updaptedPlague = await plagueService.UpdatePlague(IdPlague, PlagueName, IdTypePlague);
            return Ok(updaptedPlague);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlague(int id)
        {
            var plague = await plagueService.DeletePlague(id);
            if (plague == null) return NotFound();
            return Ok(plague);
        }

    }
}
