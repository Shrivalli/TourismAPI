using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Spot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? SpotName { get; set; }
        public string? SpotAddress { get; set; }
        public double SpotDuration { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? PackageImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }

        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public ICollection<Hotel>? Hotel { get; set; }
    }
}
