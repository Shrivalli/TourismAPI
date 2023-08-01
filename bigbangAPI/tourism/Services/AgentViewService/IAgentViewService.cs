using tourismBigBang.Models;

namespace tourismBigBang.Services.AgentViewService
{
    public interface IAgentViewService
    {
        Task<List<Spot>> GetSpotByPlaceId(int placeId);
        Task<List<Hotel>> GetHotelBySpotId(int spotId);
        Task<Package> PostPackageByAgent(Package package);
        Task<DaySchedule> PostDayScheduleByAgent(DaySchedule daySchedule);
    }
}
