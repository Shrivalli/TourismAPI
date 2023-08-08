using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models;
using tourismBigBang.Models.Dto;
using tourismBigBang.Models.View_Model;

namespace tourismBigBang.Services.UserViewService
{
    public interface IUserViewService
    {
        Task<List<PlanDTO>> GetPlans();
        Task<List<PackagesOverall>> GetPackageDetails(int placeId );
        Task<List<DayWiseSchedule>> GetDayWise(int packageId);
        Task<UserInfo> GetUserInfoForBooking(int id);
        Task<Booking> PostBookingDetails(Booking booking);
        Task<List<Place>> GetAllPlaces();
        Task<List<ImageGallery>> GetAllImages();
        Task<Package> GetParticularPackage(int id);
    }
}
