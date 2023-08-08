using Microsoft.EntityFrameworkCore;
using Serilog;
using tourismBigbang.Context;
using tourismBigBang.Global_Exception;
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
            if (getPlaceDetails == null)
            {
                Log.Error(" place details is null");
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return getPlaceDetails;
        }
        public async Task<List<Package>> GetPackage()
        {
            var getPackageDetails= await _context.Packages.ToListAsync();
            if (getPackageDetails == null)
            {
                Log.Error("package details are null");
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return getPackageDetails;
        }
        public async Task<Package> GetPackageById(int packageId)
        {
            var getPackageDetails = await _context.Packages.FirstOrDefaultAsync(s=>s.Id==packageId);
            if (getPackageDetails == null)
            {
                Log.Error("package details from given package id is null");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getPackageDetails;
        }
        public async Task<List<Package>> GetPackageByPlaceId(int placeId)
        {
            var packages = await _context.Packages.Where(p => p.PlaceId == placeId).ToListAsync();

            if (packages == null)
            {
                Log.Error("package details from given place id is null");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }

            return packages;
        }

        public async Task<List<ImageGallery>> GetGallery()
        {
            var getGalleryDetails = await _context.imageGalleries.ToListAsync();
            if (getGalleryDetails == null)
            {
                Log.Error("Image gallery is null");
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return getGalleryDetails;
        }
        public async Task<List<Hotel>> GetHotel()
        {
            var getHotelDetails=await  _context.Hotels.ToListAsync();
            if (getHotelDetails == null)
            {
                Log.Error("hotel is null");
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return getHotelDetails;
        }
        public async Task<Hotel> GetHotelByName(string hotelName)
        {
            var getHotelDetails = await _context.Hotels.FirstOrDefaultAsync(h => h.HotelName == hotelName);
            if (getHotelDetails == null)
            {
                Log.Error("Entered hotel name is not there");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getHotelDetails;
        }
        public async Task<List<Spot>> GetSpot()
        {
            var getSpotDetails = await _context.Spots.ToListAsync();
            if (getSpotDetails == null)
            {
                Log.Error("Spot is null");
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return getSpotDetails;
        }
        public async Task<Spot> GetSpotByName(string spotName)
        {
            var getSpotDetails = await _context.Spots.FirstOrDefaultAsync(h => h.SpotName == spotName);
            if (getSpotDetails == null)
            {
                Log.Error("Entered spot name is not there");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getSpotDetails;
        }
        public async Task<UserInfo> GetUserDetailsForBooking(int id)
        {
            var getDetails = await _context.UserInfos.FirstOrDefaultAsync(user => user.Id == id);
            if (getDetails == null)
            {
                Log.Error("Entered id is not there in booking");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getDetails;
        }
        public async Task<Booking> PostBooking(Booking booking)
        {
            if(booking==null)
            {
                Log.Error("booking is null");
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
        public async Task<List<DaySchedule>> GetDaySchedule()
        {
            var getDayScheduleDetails = await _context.DaySchedules.ToListAsync();
            if (getDayScheduleDetails == null)
            {
                Log.Error("Day schedules is null");
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return getDayScheduleDetails;
        }
        public async Task<List<DaySchedule>> GetDaySchedule(int packageId)
        {
            var getDayScheduleDetails = await _context.DaySchedules.Where(s=>s.PackageId == packageId).ToListAsync();
            if (getDayScheduleDetails == null)
            {
                Log.Error("Entered package id is not there in day schedule");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getDayScheduleDetails;
        }
    }
}
