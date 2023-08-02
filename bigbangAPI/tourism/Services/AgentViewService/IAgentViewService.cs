using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models;

namespace tourismBigBang.Services.AgentViewService
{
    public interface IAgentViewService
    {
        Task<List<Spot>> GetSpotByPlaceId(int placeId);
        Task<List<Hotel>> GetHotelBySpotId(int spotId);
        Task<DaySchedule> PostDayScheduleByAgent(DaySchedule daySchedule);
        Task<Package> PostPackageImage([FromForm] Package package);
        Task<Spot> PostSpotImage([FromForm] Spot spot);
        Task<Hotel> PostHotelImage([FromForm] Hotel hotel);
    }
}
