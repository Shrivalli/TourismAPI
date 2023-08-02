using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tourismBigbang.Context;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.AgentViewRepo
{
    public class AgentViewRepo:IAgentViewRepo
    {
        private readonly TourismContext _tourismContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AgentViewRepo(TourismContext tourismContext, IWebHostEnvironment hostEnvironment)
        {
            _tourismContext = tourismContext;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<List<Spot>> GetSpot(int placeId)
        {
            var getSpot = await _tourismContext.Spots.Where(spot => spot.PlaceId == placeId).ToListAsync();
            if(GetSpot == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getSpot;
        }
        public async Task<List<Hotel>> GetHotel(int spotId)
        {
            var getHotel = await _tourismContext.Hotels.Where(spot => spot.SpotId == spotId).ToListAsync();
            if (getHotel == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getHotel;
        }

        public async Task<DaySchedule> PostDaySchedule (DaySchedule daySchedule)
        {
            if (daySchedule == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            await _tourismContext.DaySchedules.AddAsync(daySchedule);
            await _tourismContext.SaveChangesAsync();
            return daySchedule;
        }
        public async Task<Package> PostPackageImage([FromForm] Package package)
        {
            if (package == null)
            {
                throw new ArgumentException("Invalid file");
            }

            package.ImageName = await SaveImage(package.PackageImage);
            _tourismContext.Packages.Add(package);
            await _tourismContext.SaveChangesAsync();
            return package;
        }
        public async Task<Spot> PostSpotImage([FromForm] Spot spot)
        {
            if (spot == null)
            {
                throw new ArgumentException("Invalid file");
            }

            spot.ImageName = await SaveImage(spot.SpotImage);
            _tourismContext.Spots.Add(spot);
            await _tourismContext.SaveChangesAsync();
            return spot;
        }
        public async Task<Hotel> PostHotelImage([FromForm] Hotel hotel)
        {
            if (hotel == null)
            {
                throw new ArgumentException("Invalid file");
            }

            hotel.ImageName = await SaveImage(hotel.HotelImage);
            _tourismContext.Hotels.Add(hotel);
            await _tourismContext.SaveChangesAsync();
            return hotel;
        }
        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
