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
        public int AgentId { get; set; }
        [ForeignKey("Place")]
        public int? PlaceId { get; set; }
        [Required] public string PackageName { get; set; } = string.Empty;

        [Required]
        public int? Days { get; set; }
        [Required]
        public int? PricePerPerson { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? PackageImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        public ICollection<DaySchedule>? DaySchedules { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
