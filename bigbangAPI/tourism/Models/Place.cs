using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? PlaceName { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? PlaceImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        public ICollection<Spot>? Spots { get; set; }
        public ICollection<Hotel>? Hotel { get; set; }
        public ICollection<Package>? Packages { get; set; }
    }
}
