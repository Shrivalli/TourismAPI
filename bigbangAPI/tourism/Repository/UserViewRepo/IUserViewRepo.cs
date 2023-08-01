using tourismBigbang.Models;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.UserViewRepo
{
    public interface IUserViewRepo
    {
        Task<List<Place>> GetPlace();
        Task<Package> GetPackageById(int packageId);
        Task<List<Package>> GetPackage();
        Task<List<Package>> GetPackageByPlaceId(int placeId);
        Task<List<Hotel>> GetHotel();
        Task<Hotel> GetHotelByName(string hotelName);
        Task<List<Spot>> GetSpot();
        Task<Spot> GetSpotByName(string spotName);
        Task<UserInfo> GetUserDetailsForBooking(int id);
        Task<Booking> PostBooking(Booking booking);
        Task<List<DaySchedule>> GetDaySchedule();
        Task<List<DaySchedule>> GetDaySchedule(int packageId);
    }
}