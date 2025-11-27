using Blog.API.Models.DTOs;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleService _roleService;

        public RoleController(RoleService service)
        {
            _roleService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<RoleResponseDTO>>> GetAllRolesAsync()
        {
            var roles = await _roleService.GetAllRolesAsync();

            return Ok(roles);
        }


        [HttpPost("Create")]
        public async Task<ActionResult> CreateRole(RoleRequestDTO role)
        {
            await _roleService.CreateRoleAsync(role);

            return Created();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleResponseDTO>> GetRoleIdAsync(int id)
        {
            var role = await _roleService.GetRoleIdAsync(id);

            if (role == null)
                return NotFound("Função não encontrada");
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoleAsync(int id, RoleRequestDTO role)
        {
            try
            {
                await _roleService.UpdateRoleAsync(id, role);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoleAsync(int id)
        {
            try
            {
                await _roleService.DeleteRoleAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
