namespace tourismBigBang.Models.View_Model
{
    public class DayWiseSchedule
    {
        public int Id { get; set; }
        public int DayNo { get; set; }
        public string? SpotName { get; set; }
        public string? SpotImage { get; set; }
        public string? SpotAddress { get; set; }
        public double SpotDuration { get; set; }
        public string? HotelName { get; set; }
        public string? HotelImage { get; set; }
        public int HotelRating { get; set; }
        public string? VehicleName { get; set; }
    }
}
