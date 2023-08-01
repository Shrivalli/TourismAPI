using tourismBigBang.Models;

namespace tourismBigBang.Repository.UserViewRepo
{
    public interface IUserViewRepo
    {
        Task<List<Place>> GetPlace();
        Task<Package> GetPackageById(int packageId);
        Task<List<Package>> GetPackage();
        Task<List<Hotel>> GetHotel();
        Task<Hotel> GetHotelByName(string hotelName);
        Task<List<Spot>> GetSpot();
        Task<Spot> GetSpotByName(string spotName);
        Task<List<Booking>> GetBooking();
        Task<List<DaySchedule>> GetDaySchedule();
        Task<List<DaySchedule>> GetDaySchedule(int packageId);
    }
}