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
        public int SpotDuration { get; set; }

        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public ICollection<DaySchedule>? DaySchedules { get; set; }
    }
}
