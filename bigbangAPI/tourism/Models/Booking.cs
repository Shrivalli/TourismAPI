using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The PackageId field is required.")]
        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [Required(ErrorMessage = "The StartingDate field is required.")]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartingDate { get; set; }

        [Required(ErrorMessage = "The EndingDate field is required.")]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndingDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The PeopleCount field must be greater than 0.")]
        public int PeopleCount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The TotalPrice field must be greater than 0.")]
        public int TotalPrice { get; set; }

        [StringLength(15, ErrorMessage = "The TransactionStatus must be at most 15 characters long.")]
        public string? TransactionStatus { get; set; }
    }
}
