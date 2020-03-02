using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegistrDto)
        {
            // validate request

            userForRegistrDto.Username = userForRegistrDto.Username.ToLower();

            if (await _repo.UserExists(userForRegistrDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegistrDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegistrDto.Password);

            return StatusCode(201);
        }
    }
}