using Microsoft.AspNetCore.Mvc;
using tourismBigbang.Models;
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
        [HttpPost("AfterApproved")]
        public async Task<ActionResult<AgentApproval>> AfterApproved(AgentApproval agentApproval)
        {
            try
            {
                var post = await _adminViewService.AfterApproved(agentApproval);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        [HttpGet("GetForApproval")]
        public async Task<ActionResult<List<AgentApproval>>> GetForApproval()
        {
            try
            {
                var get = await _adminViewService.GetForApproval();
                return Ok(get);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
