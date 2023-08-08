using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models;
using tourismBigBang.Services.AgentViewService;

namespace tourismBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentViewController:ControllerBase
    {
        private readonly IAgentViewService _agentViewService;
        public AgentViewController(IAgentViewService agentViewService)
        {
            _agentViewService = agentViewService;
        }
        [Authorize(Roles ="Agent")]
        [HttpGet("SpotByPlaceId")]
        public async Task<ActionResult<List<Spot>>> GetSpotByPlaceId(int placeId)
        {
            try
            {
                var spotByPlaceId = await _agentViewService.GetSpotByPlaceId(placeId);
                return Ok(spotByPlaceId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Agent")]
        [HttpGet("HotelBySpotId")]
        public async Task<ActionResult<List<Hotel>>> GetHotelBySpotId(int spotId)
        {
            try
            {
                var hotelBySpotId = await _agentViewService.GetHotelBySpotId(spotId);
                return Ok(hotelBySpotId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Agent")]
        [HttpPost("PostDayWise")]
        public async Task<ActionResult<DaySchedule>> PostDayScheduleByAgent(DaySchedule daySchedule)
        {
            try
            {
                var post = await _agentViewService.PostDayScheduleByAgent(daySchedule);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Agent")]
        [HttpPost("PostPackageWithImage")]
        public async Task<ActionResult<Package>> PostPackageImage([FromForm] Package package)
        {
            try
            {
                var post = await _agentViewService.PostPackageImage(package);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Agent")]
        [HttpPost("PostSpotWithImage")]
        public async Task<ActionResult<Package>> PostSpotImage([FromForm] Spot spot)
        {
            try
            {
                var post = await _agentViewService.PostSpotImage(spot);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Agent")]
        [HttpPost("PostHotelWithImage")]
        public async Task<ActionResult<Hotel>> PostHotelImage([FromForm] Hotel hotel)
        {
            try
            {
                var post = await _agentViewService.PostHotelImage(hotel);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Agent")]
        [HttpGet("GetLastPackage")]
        public async Task<ActionResult<Package>> GetLastPackage()
        {
            try
            {
                var lastPackage = await _agentViewService.GetLastPackage();
                return Ok(lastPackage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
