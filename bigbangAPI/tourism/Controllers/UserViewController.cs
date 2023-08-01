using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models.Dto;
using tourismBigBang.Models.View_Model;
using tourismBigBang.Services.UserViewService;

namespace tourismBigBang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserViewController:ControllerBase
    {
        private readonly IUserViewService _userViewService;
        public UserViewController(IUserViewService userViewService)
        {
            _userViewService = userViewService;
        }
        [HttpGet]
        public async Task<ActionResult<List<PlanDTO>>> GetPlans()
        {
            var get = await _userViewService.GetPlans();
            return Ok(get);
        }
        public async Task<ActionResult<List<OverallPackage>>> GetPackageDetails(int placeId)
        {
            var get = await _userViewService.GetPackageDetails(placeId);
            return Ok(get);
        }
    }
}
