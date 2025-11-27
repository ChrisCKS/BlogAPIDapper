using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;

namespace Blog.API.Services
{
    public class RoleService
    {
        private RoleRepository _roleRepository;

        public RoleService(RoleRepository rolerepository)
        {
            _roleRepository = rolerepository;
        }

        public async Task<List<RoleResponseDTO>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task CreateRoleAsync(RoleRequestDTO role)
        {
            var newRole = new Role(role.Name, role.Name.ToLower().Replace(" ", "-"));

            await _roleRepository.CreateRoleAsync(newRole);
        }

        public async Task<RoleResponseDTO> GetRoleIdAsync(int id)
        {
            return await _roleRepository.GetRoleIdAsync(id);
        }

        public async Task UpdateRoleAsync(int id, RoleRequestDTO role)
        {
            var roleExist = await _roleRepository.GetRoleIdAsync(id);
            if (roleExist == null)
                throw new Exception("Função não encontrada.");

            var updateRole = new Role(role.Name, role.Name.ToLower().Replace(" ", "-"));

            await _roleRepository.UpdateRoleAsync(id, updateRole);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var roleExist = await _roleRepository.GetRoleIdAsync(id);
            if (roleExist == null)
                throw new Exception("Função não encontrada.");

            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}
