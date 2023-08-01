using System.ComponentModel.DataAnnotations;

namespace tourismBigBang.Models
{
    public class AgentApproval
    {
        [Key]
        [StringLength(15, ErrorMessage = "The Username must be at most 15 characters long.")]
        public string? Username { get; set; }
        public string? Password { get; set; }

        [StringLength(15, ErrorMessage = "The Role must be at most 15 characters long.")]
        public string? Role { get; set; }

        [StringLength(35, ErrorMessage = "The AgencyName must be at most 35 characters long.")]
        public string? AgencyName { get; set; }

        [StringLength(30, ErrorMessage = "The Email must be at most 30 characters long.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public long? PhoneNumber { get; set; }
    }
}
