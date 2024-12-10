using hahahton.Dtos;
using hahahton.Models;

namespace hahahton.Services.Interfaces
{
    public interface IUserService
    {
        User CreateUser(RegistrationDto dto);
        User? FindByEmail(string email);
    }
}
