using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
                Log.Error(" Getting spot by place Id is null");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getSpot;
        }
        public async Task<List<Hotel>> GetHotel(int spotId)
        {
            var getHotel = await _tourismContext.Hotels.Where(spot => spot.SpotId == spotId).ToListAsync();
            if (getHotel == null)
            {
                Log.Error(" Getting hotel by spot Id is null");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return getHotel;
        }

        public async Task<DaySchedule> PostDaySchedule (DaySchedule daySchedule)
        {
            if (daySchedule == null)
            {
                Log.Error("Passed object in postDaySchedule is null");
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
                Log.Error(" posting image in package is null");
                throw new ArgumentException("Invalid file");
            }
            if (package.PackageImage == null)
            {
                throw new Exception("No images in package");
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
                Log.Error(" posting image in spot is null");
                throw new ArgumentException("Invalid file");
            }
            if(spot.SpotImage == null)
            {
                throw new Exception("No images in spot");
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
                Log.Error(" posting image in hotel is null");
                throw new ArgumentException("Invalid file");
            }
            if (hotel.HotelImage == null)
            {
                throw new Exception("No images in hotel");
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
        public async Task<List<Package>> GetAllPackages()
        {
            var packages = await _tourismContext.Packages.ToListAsync();

            if (packages == null || packages.Count == 0)
            {
                Log.Error(" package is null");
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }

            return packages;
        }


    }
}
