using Microsoft.EntityFrameworkCore;
using tourismBigbang.Context;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.AgentViewRepo
{
    public class AgentViewRepo:IAgentViewRepo
    {
        private readonly TourismContext _tourismContext;
        public AgentViewRepo(TourismContext tourismContext)
        {
            _tourismContext = tourismContext;
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
        public async Task<Package> PostPackage(Package package)
        {
            if (package == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            await _tourismContext.Packages.AddAsync(package);
            await _tourismContext.SaveChangesAsync();
            return package;
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
    }
}
