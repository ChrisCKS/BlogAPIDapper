namespace Blog.API.Models.DTOs
{
    public class UserRequestDTO
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string Bio { get; private set; }
        public string Image { get; private set; }
    }
}
