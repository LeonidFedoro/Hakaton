using hahahton.Dtos;
using hahahton.Models;
using hahahton.Services.Interfaces;

namespace hahahton.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;

        public AuthService(IUserService userService, ITokenService tokenService, IHashService hashService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _hashService = hashService;
        }

        public User Registration(RegistrationDto dto)
        {
            return _userService.CreateUser(dto);
        }

        public string Login(LoginDto dto)
        {
            var user = _userService.FindByEmail(dto.Email);
            if (!_hashService.VerifyPassword(dto.Password, user.Password))
            {

                throw new BadHttpRequestException("Неправильный пароль");
            }

            return _tokenService.GenerateToken(user.Id);
        }
    }
}