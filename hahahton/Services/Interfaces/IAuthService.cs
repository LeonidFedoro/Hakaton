using hahahton.Dtos;
using hahahton.Models;

namespace hahahton.Services.Interfaces
{
    public interface IAuthService
    {
        User Registration(RegistrationDto dto);
        string Login(LoginDto dto);

    }
}
