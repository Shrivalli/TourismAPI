using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Transaction
    {
        [Key] public int Id { get; set; }
        public string? TransactionStatus { get; set; }
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
    }
}
