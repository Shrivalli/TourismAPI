using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        [Column(TypeName ="Date")]
        public DateTime StartingDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndingDate { get; set; }
        public int PeopleCount { get; set; }
        public int TotalPrice { get; set; }

        public string? TransactionStatus { get; set; }
    }
}
