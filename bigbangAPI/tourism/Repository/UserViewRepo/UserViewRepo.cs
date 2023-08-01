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
        public async Task<Package> GetPackageById(int packageId)
        {
            var getPackageDetails = await _context.Packages.FirstOrDefaultAsync(s=>s.Id==packageId);
            return getPackageDetails == null ? throw new Exception("Package by id is empty") : getPackageDetails;
        }
        public async Task<List<Hotel>> GetHotel()
        {
            var getHotelDetails=await  _context.Hotels.ToListAsync();
            return getHotelDetails;
        }
        public async Task<Hotel> GetHotelByName(string hotelName)
        {
            var getHotelDetails = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelName == hotelName) ?? throw new Exception("Hotel by id is empty");
            return getHotelDetails;
        }
        public async Task<List<Spot>> GetSpot()
        {
            var getSpotDetails = await _context.Spots.ToListAsync();
            return getSpotDetails;
        }
        public async Task<Spot> GetSpotByName(string spotName)
        {
            var getSpotDetails = await _context.Spots.FirstOrDefaultAsync(h => h.SpotName == spotName) ?? throw new Exception("Spot by id is empty");
            return getSpotDetails;
        }
        public async Task<List<Booking>> GetBooking()
        {
            var getBookingDetails= await _context.Bookings.ToListAsync();
            return getBookingDetails;
        }
        public async Task<List<DaySchedule>> GetDaySchedule()
        {
            var getDayScheduleDetails = await _context.DaySchedules.ToListAsync();
            return getDayScheduleDetails;
        }
        public async Task<List<DaySchedule>> GetDaySchedule(int packageId)
        {
            var getDayScheduleDetails = await _context.DaySchedules.Where(s=>s.PackageId == packageId).ToListAsync();
            return getDayScheduleDetails;
        }
    }
}
