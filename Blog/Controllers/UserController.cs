using Blog.API.Models.DTOs;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser(UserRequestDTO user)
        {
            await _userService.CreateUserAsync(user);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetUserIdAsync(int id)
        {
            var user = await _userService.GetUserIdAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado.");
            return Ok(user);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateUserAsync(int id, UserRequestDTO user)
        {
            try
            {
                await _userService.UpdateUserAsync(id, user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
