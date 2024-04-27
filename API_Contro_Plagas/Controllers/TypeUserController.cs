using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class TypeUserController(ITypeUserService typeUserService) :ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeUser>>> GetTypeUsers()
        {
            IEnumerable<TypeUser> typeUsers = await typeUserService.GetTypeUsers();
            return Ok(typeUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TypeUser>> GetTypeUser(int id)
        {
            TypeUser? typeUser = await typeUserService.GetTypeUser(id);
            if (typeUser == null) return NotFound();
            return Ok(typeUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeUser(
           string TypeUserName
        )
        {
            var typeUser = await typeUserService.CreateTypeUser(TypeUserName);
            return CreatedAtAction(nameof(GetTypeUser), new { id = typeUser.IdTypeUser }, typeUser);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTypeUser(
          int IdTypeUser,
          string? TypeUserName
        )
        {
            var updaptedTypeUser = await typeUserService.UpdateTypeUser(IdTypeUser, TypeUserName);
            return Ok(updaptedTypeUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeUser(int id)
        {
            var typeUser = await typeUserService.DeleteTypeUser(id);
            if (typeUser == null) return NotFound();
            return Ok(typeUser);
        }
        
       
    }
}
