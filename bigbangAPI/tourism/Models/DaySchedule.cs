using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class DaySchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        public string? SpotName { get; set; }
        public string? HotelName { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public int Daywise { get; set; }
    }
}
