using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Hotel
    {
        [Key] public int Id { get; set; }
        public string? HotelName { get; set; }
        [ForeignKey("Spot")]
        public int SpotId { get; set; }
        public int HotelRating { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? HotelImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
    }
}
