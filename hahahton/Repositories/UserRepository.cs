using hahahton.Data;
using hahahton.Dtos;
using hahahton.Models;
using hahahton.Repositories.Interfaces;

namespace hahahton.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Create(RegistrationDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
                UserName = dto.UserName,
                Password = dto.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User? FindByEmailOrUsername(string email, string username)
        {
            return _context.Users
                .FirstOrDefault(u => u.Email == email || u.UserName == username);
        }

        public User? FindByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
