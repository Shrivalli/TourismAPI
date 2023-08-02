using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.AgentViewRepo
{
    public interface IAgentViewRepo
    {
        Task<List<Spot>> GetSpot(int placeId);
        Task<List<Hotel>> GetHotel(int spotId);
        Task<DaySchedule> PostDaySchedule(DaySchedule daySchedule);
        Task<Package> PostPackageImage([FromForm] Package package);
        Task<Spot> PostSpotImage([FromForm] Spot spot);
        Task<Hotel> PostHotelImage([FromForm] Hotel hotel);
        Task<string> SaveImage(IFormFile imageFile);
    }
}
