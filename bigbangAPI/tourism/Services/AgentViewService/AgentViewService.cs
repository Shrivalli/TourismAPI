using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;
using tourismBigBang.Repository.AgentViewRepo;
namespace tourismBigBang.Services.AgentViewService
{
    public class AgentViewService:IAgentViewService
    {
        private readonly IAgentViewRepo _agentViewRepo;
        public AgentViewService(IAgentViewRepo agentViewRepo)
        {
            _agentViewRepo = agentViewRepo;
        }
      public async Task<List<Spot>> GetSpotByPlaceId (int placeId)
        {
            var get= await _agentViewRepo.GetSpot(placeId);
            if (get == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return get;
        }
        public async Task<List<Hotel>> GetHotelBySpotId(int spotId)
        {
            var get = await _agentViewRepo.GetHotel(spotId);
            if (get == null)
            {
                throw new Exception(CustomException.ExceptionMessages["NoId"]);
            }
            return get;
        }

        public async Task<DaySchedule> PostDayScheduleByAgent(DaySchedule daySchedule)
        {
            var post = await _agentViewRepo.PostDaySchedule(daySchedule);
            if (post == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return post;
        }
        public async Task<Package> PostPackageImage([FromForm] Package package)
        {
            if (package == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _agentViewRepo.PostPackageImage(package);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return item;
        }
        public async Task<Spot> PostSpotImage([FromForm] Spot spot)
        {
            if (spot == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _agentViewRepo.PostSpotImage(spot);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return item;
        }
        public async Task<Hotel> PostHotelImage([FromForm] Hotel hotel)
        {
            if (hotel == null)
            {
                throw new Exception("Invalid file");
            }
            var item = await _agentViewRepo.PostHotelImage(hotel);
            if (item == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return item;
        }
    }
}
