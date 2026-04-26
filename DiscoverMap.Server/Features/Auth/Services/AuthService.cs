using DiscoverMap.Server.Features.Auth.DTOs;
using DiscoverMap.Server.Features.Auth.Models;
using DiscoverMap.Server.Features.Auth.Repositories.Interfaces;

namespace DiscoverMap.Server.Features.Auth.Services
{
    public class AuthService
    {
        private readonly IUserRepository _repo;

        public AuthService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> RegisterAsync(RegisterDTO dto)
        {
            var exists = await _repo.ExistsByEmailOrUsernameAsync(dto.Email, dto.Username);
            if (exists) return false;

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = "not-hashed-yet" // BCrypt goes here later
            };

            await _repo.AddAsync(user);
            return true;
        }

        public async Task<User?> LoginAsync(LoginDTO dto)
        {
            var user = await _repo.GetByEmailAsync(dto.Email);
            if (user == null) return null;

            // Password check goes here later
            return user;
        }
    }
}
