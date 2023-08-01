using Microsoft.AspNetCore.Mvc;
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
                        MinimumPrice = placePackages.Min(pp => pp.PricePerPerson)
                    })
                .ToList();

            // Create a list of PlanDTO objects based on the 'result'
            var planDTOs = result.Select(r => new PlanDTO
            {
                Id = r.Id,
                PlaceName = r.PlaceName,
                MinimumPrice = r.MinimumPrice
            }).ToList();

            return planDTOs;
        }
        //Displaying the packages based on the place
        public async Task<List<OverallPackage>> GetPackageDetails(int placeId)
        {
            var packages = await _userViewRepo.GetPackage(); // Assuming GetUserViewRepo returns a collection of packages
            var daySchedules = await _userViewRepo.GetDaySchedule(); // Assuming GetUserViewRepo returns a collection of day schedules

            var joinedData = (from package in packages
                              join daySchedule in daySchedules
                              on package.Id equals daySchedule.PackageId into packageDaySchedules
                              select new OverallPackage
                              {
                                  PackageId = package.Id,
                                  PackageName = package.PackageName,
                                  Activities = packageDaySchedules.Select(ds => ds.SpotName).Count(),
                                  Hotel = packageDaySchedules.Select(ds => ds.HotelName).Count(),
                                  PricePerPerson= package.PricePerPerson,
                                  PersonLimit= package.PersonLimit,
                                  Food= package.Food,
                                  Iternary = package.Iternary,
                                  Days=package.Days
                              }).ToList();

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

            return dayWiseSchedules;
        }

    }
}
