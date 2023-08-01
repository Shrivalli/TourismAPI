using tourismBigBang.Models;

namespace tourismBigBang.Repository.AgentViewRepo
{
    public interface IAgentViewRepo
    {
        Task<List<Spot>> GetSpot(int placeId);
        Task<List<Hotel>> GetHotel(int spotId);
        Task<Package> PostPackage(Package package);
        Task<DaySchedule> PostDaySchedule(DaySchedule daySchedule);
    }
}
