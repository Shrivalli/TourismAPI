using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tourismBigBang.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "The FirstName must be at most 20 characters long.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The FirstName must contain only alphabets.")]
        public string? FirstName { get; set; }

        [StringLength(20, ErrorMessage = "The LastName must be at most 20 characters long.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The LastName must contain only alphabets.")]
        public string? LastName { get; set; }

        [StringLength(15, ErrorMessage = "The Username must be at most 15 characters long.")]
        public string? Username { get; set; }

        public byte[]? Password { get; set; }


        [StringLength(15, ErrorMessage = "The Role must be at most 15 characters long.")]
        public string? Role { get; set; }

        [StringLength(35, ErrorMessage = "The AgencyName must be at most 35 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The AgencyName must contain only alphabets.")]
        public string? AgencyName { get; set; }

        [StringLength(30, ErrorMessage = "The Email must be at most 30 characters long.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }


        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public long? PhoneNumber { get; set; }

        public byte[]? Hashkey { get; set; }
        [StringLength(10, ErrorMessage = "The IsActive must be at most 10 characters long.")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "The IsActive must contain only alphabets.")]
        public bool? IsActive { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
        public ICollection<Package>? Packages { get; set; }
    }
}
