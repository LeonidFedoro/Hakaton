
using hahahton.Models.Enum;

namespace hahahton.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? UserStudPictureUrl { get; set; }
        public int? UserStudId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public City? City { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public DateTime? ResetTokenExpiration { get; set; }
        public Role? Role { get; set; }
        public List<Interest> Interests { get; set; }

    }
}
