using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models;
using tourismBigBang.Services.AdminViewService;

namespace tourismBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminViewController:ControllerBase
    {
        private readonly IAdminViewService _adminViewService;
        public AdminViewController(IAdminViewService adminViewService)
        {
            _adminViewService = adminViewService;
        }
       
        [HttpPost("BeforeApproval")]
        public async Task<ActionResult<UserInfo>> BeforeApproval(UserInfo userInfo)
        {
            try
            {
                var post = await _adminViewService.BeforeApproval(userInfo);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetApproval")]
        public async Task<ActionResult<List<UserInfo>>> Approval()
        {
            try
            {
                var get = await _adminViewService.Approval();
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("AgentApproved")]
        public async Task<ActionResult<UserInfo>> ApprovedAgent(int id)
        {
            try
            {
                var update = await _adminViewService.ApprovedAgent(id);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("AgentRejected")]
        public async Task<ActionResult<UserInfo>> RejectApproval(int id)
        {
            try
            {
                var delete = await _adminViewService.RejectApproval(id);
                return Ok(delete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("PostImageGallery")]
        public async Task<ActionResult<ImageGallery>> PostImage([FromForm] ImageGallery gallery)
        {
            try
            {
                var post = await _adminViewService.PostImage(gallery);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("PostPlaceWithImage")]
        public async Task<ActionResult<Place>> PostPlaceImage([FromForm] Place place)
        {
            try
            {
                var post = await _adminViewService.PostPlaceImage(place);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
