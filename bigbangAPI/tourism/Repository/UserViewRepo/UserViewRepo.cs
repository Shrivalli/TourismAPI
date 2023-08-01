using Microsoft.EntityFrameworkCore;
using tourismBigbang.Context;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.UserViewRepo
{
    public class UserViewRepo : IUserViewRepo
    {
        private readonly TourismContext _context;
        public UserViewRepo(TourismContext context)
        {
            _context = context;
        }
        public async Task<List<Place>> GetPlace() 
        {
            var getPlaceDetails = await _context.Places.ToListAsync();
            return getPlaceDetails;
        }
        public async Task<List<Package>> GetPackage()
        {
            var getPackageDetails= await _context.Packages.ToListAsync();
            return getPackageDetails;
        }
        public async Task<List<Hotel>> GetHotel()
        {
            var getHotelDetails=await  _context.Hotels.ToListAsync();
            return getHotelDetails;
        }

        public async Task<List<Spot>> GetSpot()
        {
            var getSpotDetails = await _context.Spots.ToListAsync();
            return getSpotDetails;
        }
        public async Task<List<Vehicle>> GetVehicle()
        {
            var getVehicleDetails = await _context.Vehicles.ToListAsync();
            return getVehicleDetails;
        }
        public async Task<List<Booking>> GetBooking()
        {
            var getBookingDetails= await _context.Bookings.ToListAsync();
            return getBookingDetails;
        }
    }
}
