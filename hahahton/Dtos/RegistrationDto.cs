using System.ComponentModel.DataAnnotations;

namespace hahahton.Dtos
{
    public class RegistrationDto
    {
        [EmailAddress(ErrorMessage = "Некорректный формат email.")]
        public string Email { get; set; }


        [MinLength(8, ErrorMessage = "Пароль должен содержать как минимум 8 символов.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "Пароль должен содержать минимум одну заглавную букву, одну строчную букву, одну цифру и один специальный символ.")]

        public string Password { get; set; }

        [MinLength(3, ErrorMessage = "Имя пользователя должно содержать минимум 3 символа.")]
        public string UserName { get; set; }
    }
}
