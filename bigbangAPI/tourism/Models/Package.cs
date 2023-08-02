using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tourismBigBang.Helpers;
using Xunit.Sdk;

namespace tourismBigBang.Models
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The UserInfoId field is required.")]
        [ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }

        [Required(ErrorMessage = "The PlaceId field is required.")]
        [ForeignKey("Place")]
        public int PlaceId { get; set; }

        [Required(ErrorMessage = "The PackageName field is required.")]
        [StringLength(30, ErrorMessage = "The PackageName must be at most 30 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The PackageName must contain only alphabets.")]
        public string PackageName { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "The Days field must be greater than 0.")]
        public int Days { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The PricePerPerson field must be greater than 0.")]
        public int PricePerPerson { get; set; }

        [StringLength(50, ErrorMessage = "The Food must be at most 50 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The FoodName must contain only alphabets.")]
        public string? Food { get; set; }

        [StringLength(50, ErrorMessage = "The Iternary must be at most 50 characters long.")]
        public string? Iternary { get; set; }

        [StringLength(100, ErrorMessage = "The ImageName must be at most 100 characters long.")]
        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image is required")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? PackageImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }

        public ICollection<DaySchedule>? DaySchedules { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
