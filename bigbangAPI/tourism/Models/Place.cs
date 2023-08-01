using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The PlaceName field is required.")]
        [StringLength(20, ErrorMessage = "The PlaceName must be at most 20 characters long.")]
        public string? PlaceName { get; set; }

        [StringLength(100, ErrorMessage = "The ImageName must be at most 100 characters long.")]
        public string? ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "The PlaceImage field is required.")]
        public IFormFile? PlaceImage { get; set; }

        [NotMapped]
        public string? ImageSrc { get; set; }

        public ICollection<Spot>? Spots { get; set; }

        public ICollection<Package>? Packages { get; set; }
    }
}
