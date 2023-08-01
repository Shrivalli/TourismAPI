using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("UserInfo")]
        public int UserInfoId { get; set; }
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public string PackageName { get; set; } = string.Empty;
        public int Days { get; set; }
        public int PricePerPerson { get; set; }
        public int PersonLimit { get; set; }
        public string? Food { get; set; }
        public string? Iternary { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? PackageImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        public ICollection<DaySchedule>? DaySchedules { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
