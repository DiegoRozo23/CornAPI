

using API_Contro_Plagas.Models;
using API_Contro_Plagas.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Contro_Plagas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController(IUserService userService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            IEnumerable<User> users = await userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User? user = await userService.GetUser(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]

        public async Task<IActionResult> CreateUser(
           string UserName,
           string UserLastname,
           string UserEmail,
           int IdTypeUser
        )
        {
            var user = await userService.CreateUser(UserName, UserLastname, UserEmail,IdTypeUser);
            return CreatedAtAction(nameof(GetUser), new { id = user.IdUser }, user);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateUser(
           int IdUser,
           string? UserName,
           string? UserLastname,
           string? UserEmail,
           int? IdTypeUser
        )
        {
            var updaptedUser = await userService.UpdateUser(IdUser, UserName, UserLastname, UserEmail, IdTypeUser);
            return Ok(updaptedUser);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userService.DeleteUser(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
