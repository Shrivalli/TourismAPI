using Microsoft.AspNetCore.Mvc;
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
        public UserViewService(IUserViewRepo userViewRepo)
        {
            _userViewRepo = userViewRepo;
        }
        //Displaying all the places and the minimum price
        public async Task<List<PlanDTO>> GetPlans()
        {
            var places = await _userViewRepo.GetPlace();
            var packages = await _userViewRepo.GetPackage();

            var result = places
                .GroupJoin(packages,
                    place => place.Id,
                    package => package.PlaceId,
                    (place, placePackages) => new
                    {
                        Id = place.Id,
                        PlaceName = place.PlaceName,
                        MinimumPrice = placePackages.Min(pp => pp.PricePerPerson),
                        Image=place.ImageName
                    })
                .ToList();

            // Create a list of PlanDTO objects based on the 'result'
            var planDTOs = result.Select(r => new PlanDTO
            {
                Id = r.Id,
                PlaceName = r.PlaceName,
                MinimumPrice = r.MinimumPrice,
                Image=r.Image
            }).ToList();
            if(planDTOs==null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return planDTOs;
        }
        //Displaying the packages based on the place
        public async Task<List<OverallPackage>> GetPackageDetails(int placeId)
        {
            var packages = await _userViewRepo.GetPackageByPlaceId(placeId); // Assuming GetUserViewRepo returns a collection of packages
            var daySchedules = await _userViewRepo.GetDaySchedule(); // Assuming GetUserViewRepo returns a collection of day schedules

            var joinedData = (from package in packages
                              join daySchedule in daySchedules
                              on package.Id equals daySchedule.PackageId into packageDaySchedules
                              select new OverallPackage
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
            if (joinedData == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return joinedData;
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
            if (dayWiseSchedules == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return dayWiseSchedules;
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
            if (get == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return get;
        }
    }
}
