using tourismBigBang.Models;

namespace tourismBigBang.Repository.UserViewRepo
{
    public interface IUserViewRepo
    {
        Task<List<Place>> GetPlace();
        Task<List<Package>> GetPackage();
        Task<List<Hotel>> GetHotel();
        Task<List<Spot>> GetSpot();
        Task<List<Booking>> GetBooking();
        Task<List<Vehicle>> GetVehicle();
    }
}