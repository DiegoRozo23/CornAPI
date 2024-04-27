

using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TypePlagueController(ITypePlagueService typePlagueService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypePlague>>> GetTypePlagues()
        {
            IEnumerable<TypePlague> typePlagues = await typePlagueService.GetTypePlagues();
            return Ok(typePlagues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypePlague>> GetTypePlague(int id)
        {
            TypePlague? typePlague = await typePlagueService.GetTypePlague(id);
            if (typePlague == null) return NotFound();
            return Ok(typePlague);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTypePlague(
           string TypePlagueName
         )
        {
            var typePlague = await typePlagueService.CreateTypePlague(TypePlagueName);
            return CreatedAtAction(nameof(GetTypePlague), new { id = typePlague.IdTypePlague }, typePlague);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateTypePlague(
          int IdTypePlague,
          string? TypePlagueName
        )
        {
            var updaptedTypePlague = await typePlagueService.UpdateTypePlague(IdTypePlague, TypePlagueName);
            return Ok(updaptedTypePlague);
        }
    }
}
