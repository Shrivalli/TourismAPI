using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;
using tourismBigBang.Models.Dto;
using tourismBigBang.Models.View_Model;
using tourismBigBang.Repository.UserViewRepo;

namespace tourismBigBang.Services.UserViewService
{
    public class UserViewService : IUserViewService
    {
        private readonly IUserViewRepo _userViewRepo;
        private readonly IWebHostEnvironment _hostEnvironment;
        public UserViewService(IUserViewRepo userViewRepo, IWebHostEnvironment hostEnvironment)
        {
            _userViewRepo = userViewRepo;
            _hostEnvironment = hostEnvironment;
        }
        //Displaying all the places and the minimum price
        public async Task<List<PlanDTO>> GetPlans()
        {
            var places = await _userViewRepo.GetPlace();
            var packages = await _userViewRepo.GetPackage();

            if (places == null || packages == null)
            {
                return new List<PlanDTO>();
            }

            var packageGroups = packages.GroupBy(p => p.PlaceId, (key, group) => new { PlaceId = key, MinimumPrice = group.Min(p => p.PricePerPerson) });

            var planDTOs = (from place in places
                           join packageGroup in packageGroups on place.Id equals packageGroup.PlaceId into packagesForPlace
                           from package in packagesForPlace.DefaultIfEmpty()
                           select new PlanDTO
                           {
                               Id = place.Id,
                               PlaceName = place.PlaceName,
                               MinimumPrice = package?.MinimumPrice ?? 0,
                               Image = place.ImageName ?? "" // Provide a default value if ImageSrc is null
                           }).ToList();


            var imageList = new List<PlanDTO>();
            foreach (var plan in planDTOs)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var filePath = Path.Combine(uploadsFolder, plan.Image);

                var imageBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                var imageBase64 = Convert.ToBase64String(imageBytes);

                var tourData = new PlanDTO
                {
                    Id = plan.Id,
                    PlaceName = plan.PlaceName,
                    MinimumPrice = plan.MinimumPrice,
                    Image = imageBase64
                };
                imageList.Add(tourData);
            }

            return imageList;
        }

        //Displaying the packages based on the place
        public async Task<List<PackagesOverall>> GetPackageDetails(int placeId)
        {
            var packages = await _userViewRepo.GetPackageByPlaceId(placeId); // Assuming GetUserViewRepo returns a collection of packages
            var daySchedules = await _userViewRepo.GetDaySchedule(); // Assuming GetUserViewRepo returns a collection of day schedules
            Console.WriteLine($"Number of packages retrieved: {packages.Count}");
            Console.WriteLine($"Number of daySchedules retrieved: {daySchedules.Count}");

            var joinedData = (from package in packages
                              join daySchedule in daySchedules
                              on package.Id equals daySchedule.PackageId into packageDaySchedules
                              select new PackagesOverall
                              {
                                  PackageId = package.Id,
                                  PackageName = package.PackageName,
                                  Activities = packageDaySchedules.Select(ds => ds.SpotName).Distinct().Count(),
                                  Hotel = packageDaySchedules.Select(ds => ds.HotelName).Distinct().Count(),
                                  PricePerPerson= package.PricePerPerson,
                                  Food= package.Food,
                                  Iternary = package.Iternary,
                                  Days=package.Days,
                                  Image=package.ImageName
                              }).ToList();
            foreach (var data in joinedData)
            {
                Console.WriteLine($"PackageId: {data.PackageId}, PricePerPerson: {data.PricePerPerson}");
            }
            var imageList = new List<PackagesOverall>();
            foreach (var image in joinedData)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var filePath = Path.Combine(uploadsFolder, image.Image);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                var tourData = new PackagesOverall
                {
                    PackageId = image.PackageId,
                    PackageName = image.PackageName,
                    Activities = image.Activities,
                    Hotel = image.Hotel,
                    Iternary=image.Iternary,
                    Food=image.Food,
                    PricePerPerson=image.PricePerPerson,
                    Days=image.Days,
                    Image = Convert.ToBase64String(imageBytes)
                };
                imageList.Add(tourData);
            }
            return imageList;
        }
        //Getting the DayWise of the particular package id
        public async Task<List<DayWiseSchedule>> GetDayWise(int packageId)
        {
            var daySchedules = await _userViewRepo.GetDaySchedule(packageId);
            var package = await _userViewRepo.GetPackageById(packageId);

            var dayWiseSchedules = new List<DayWiseSchedule>();

            for (int dayNo = 1; dayNo <= package.Days; dayNo++)
            {
                var daySchedule = daySchedules.FirstOrDefault(ds => ds.Daywise == dayNo);
                if(daySchedule==null)
                {
                    throw new Exception("daySchedule is null");
                }
                else
                {
                    var spot = await _userViewRepo.GetSpotByName(daySchedule.SpotName ?? "");
                    var hotel = await _userViewRepo.GetHotelByName(daySchedule.HotelName ?? "");

                    var dayWiseSchedule = new DayWiseSchedule
                    {
                        Id = daySchedule.Id,
                        DayNo = dayNo,
                        SpotName = daySchedule.SpotName,
                        SpotImage = spot?.ImageName,
                        SpotAddress = spot?.SpotAddress,
                        SpotDuration = spot?.SpotDuration ?? 0,
                        HotelName = daySchedule.HotelName,
                        HotelImage = hotel?.ImageName,
                        HotelRating = hotel?.HotelRating ?? 0,
                        VehicleName = daySchedule.VehicleName
                    };

                    dayWiseSchedules.Add(dayWiseSchedule);
                }
            }
            var imageList = new List<DayWiseSchedule>();
            foreach (var image in dayWiseSchedules)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var filePath = Path.Combine(uploadsFolder, image.SpotImage);
                var filePath2=Path.Combine(uploadsFolder, image.HotelImage);
                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                var imageBytes2 = System.IO.File.ReadAllBytes(filePath2);
                var tourData = new DayWiseSchedule
                {
                    Id = image.Id,
                    DayNo = image.DayNo,
                    SpotName = image.SpotName,
                    SpotAddress = image.SpotAddress,
                    SpotDuration = image.SpotDuration,
                    HotelName = image.HotelName,
                    SpotImage = Convert.ToBase64String(imageBytes),
                    VehicleName=image.VehicleName,
                    HotelImage=Convert.ToBase64String(imageBytes2),
                    HotelRating=image.HotelRating,
                };
                imageList.Add(tourData);
            }
            return imageList;
            
        }
        public async Task<UserInfo> GetUserInfoForBooking(int id)
        {
            var userInfo= await _userViewRepo.GetUserDetailsForBooking(id);
            if (userInfo == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return userInfo;
        }
        public async Task<Booking> PostBookingDetails(Booking booking)
        {
            var bookingDetails = await _userViewRepo.PostBooking(booking);
            if (bookingDetails == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return bookingDetails;
        }
        //Common for both UserSide and AgentSide
        public async Task<List<Place>> GetAllPlaces()
        {
            var get = await _userViewRepo.GetPlace();
          
           if(get==null)
            {
                throw new Exception("nope");
            }
            return get;
        }
        public async Task<List<ImageGallery>> GetAllImages()
        {
            var get = await _userViewRepo.GetGallery();
            var imageList = new List<ImageGallery>();
            foreach (var image in get)
            {
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var filePath = Path.Combine(uploadsFolder, image.ImageName);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                var tourData = new ImageGallery
                {
                    Id = image.Id,
                    GalleryImage = image.GalleryImage,
                    ImageSrc = image.ImageSrc,
                    ImageName = Convert.ToBase64String(imageBytes)
                };
                imageList.Add(tourData);
            }
            return imageList;

        }
    }
}
