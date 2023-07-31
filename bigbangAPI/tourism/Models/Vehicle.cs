using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Vehicle
    {
        [Key] public int Id { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleType { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? VehicleImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        public ICollection<DaySchedule>? DaySchedules { get; set; }
    }
}
