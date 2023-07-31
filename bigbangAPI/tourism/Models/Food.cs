using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tourismBigBang.Models
{
    public class Food
    {
        [Key] public int Id { get; set; }
         public string? FoodDescription { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
    }
}
