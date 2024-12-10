using hahahton.Dtos;
using hahahton.Models;

namespace hahahton.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User Create(RegistrationDto dto);
        User? FindByEmailOrUsername(string email, string username);
        User? FindByEmail(string email);
        Task<User?> GetUserByIdAsync(int id);
        Task UpdateUserAsync(User user);
    }
}
