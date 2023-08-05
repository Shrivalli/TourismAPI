using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class DaySchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The PackageId field is required.")]
        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [StringLength(25, ErrorMessage = "The SpotName must be at most 25 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The SpotName must contain only alphabets.")]
        public string? SpotName { get; set; }

        [StringLength(30, ErrorMessage = "The HotelName must be at most 30 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The HotelName must contain only alphabets.")]
        public string? HotelName { get; set; }

        [StringLength(15, ErrorMessage = "The VehicleName must be at most 15 characters long.")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "The VehicleName must contain only alphabets.")]
        public string? VehicleName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Daywise field must be greater than 0.")]
        public int Daywise { get; set; }
    }
}
