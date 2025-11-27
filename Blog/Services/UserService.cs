using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;

namespace Blog.API.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userrepository)
        {
            _userRepository = userrepository;
        }

        public async Task<List<UserResponseDTO>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task CreateUserAsync(UserRequestDTO user)
        {
            var newUser = new User(user.Name, user.Name.ToLower().Replace(" ", "-"),
                                    user.Email, user.PasswordHash, user.Bio, user.Image);

            await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<UserResponseDTO> GetUserIdAsync(int id)
        {
            return await _userRepository.GetUserIdAsync(id);
        }

        public async Task UpdateUserAsync(int id, UserRequestDTO user)
        {
            var userExist = await _userRepository.GetUserIdAsync(id);

            if (userExist == null)
                throw new Exception("Usuário não encontrado.");

            var updateUser = new User(user.Name, user.Name.ToLower().Replace(" ", "-"),
                                    user.Email, user.PasswordHash, user.Bio, user.Image);

            await _userRepository.UpdateUserAsync(id, updateUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            var userExist = await _userRepository.GetUserIdAsync(id);

            if (userExist == null)
                throw new Exception("Usuário não encontrado.");

            await _userRepository.DeleteUserAsync(id);
        }
    }
}
