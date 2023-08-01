using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The HotelName field is required.")]
        [StringLength(30, ErrorMessage = "The HotelName must be at most 100 characters long.")]
        public string? HotelName { get; set; }

        [Required(ErrorMessage = "The SpotId field is required.")]
        [ForeignKey("Spot")]
        public int SpotId { get; set; }

        [Range(1, 5, ErrorMessage = "The HotelRating field must be between 1 and 5.")]
        public int HotelRating { get; set; }

        [StringLength(100, ErrorMessage = "The ImageName must be at most 100 characters long.")]
        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "The HotelImage field is required.")]
        public IFormFile? HotelImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }
    }
}
