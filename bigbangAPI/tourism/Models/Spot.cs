using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tourismBigBang.Helpers;
using Xunit.Sdk;

namespace tourismBigBang.Models
{
    public class Spot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The SpotName field is required.")]
        [StringLength(25, ErrorMessage = "The SpotName must be at most 25 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The SpotName must contain only alphabets.")]
        public string? SpotName { get; set; }

        [StringLength(50, ErrorMessage = "The SpotAddress must be at most 50 characters long.")]
        public string? SpotAddress { get; set; }

        [Range(0.5, double.MaxValue, ErrorMessage = "The SpotDuration field must be greater than 0.5.")]
        public double SpotDuration { get; set; }

        [StringLength(100, ErrorMessage = "The ImageName must be at most 100 characters long.")]
        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Image is required")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" }, ErrorMessage = "Invalid file format. Only .jpg, .jpeg, .png, and .gif are allowed.")]
        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "Maximum file size allowed is 10MB.")]
        public IFormFile? SpotImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }

        [Required(ErrorMessage = "The PlaceId field is required.")]
        [ForeignKey("Place")]
        public int PlaceId { get; set; }

        public ICollection<Hotel>? Hotels { get; set; }
    }
}
