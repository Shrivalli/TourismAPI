using System.ComponentModel.DataAnnotations;
using tourismBigBang.Models;

namespace tourismBigbang.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? RefreshToken { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
        public ICollection<Package>? Packages { get; set; }
    }
}
