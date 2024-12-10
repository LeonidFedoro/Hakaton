
using hahahton.Dtos;
using hahahton.Models;
using hahahton.Repositories.Interfaces;
using hahahton.Services.Interfaces;

namespace hahahton.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IHashService _hashService;

        public UserService(IUserRepository repository, IHashService hashService)
        {
            _repository = repository;
            _hashService = hashService;
        }

        public User CreateUser(RegistrationDto dto)
        {
            var userDuplicate = _repository.FindByEmailOrUsername(dto.Email, dto.UserName);
            if (userDuplicate != null)
            {
                throw new InvalidOperationException("Пользователь с таким email или именем уже существует");
            }

            dto.Password = _hashService.HashPassword(dto.Password);
            return _repository.Create(dto);
        }

        public User? FindByEmail(string email)
        {
            var user = _repository.FindByEmail(email);
            if (user == null)
            {

                throw new InvalidOperationException("Пользователь не найден");
            }

            return user;
        }

    }
}
