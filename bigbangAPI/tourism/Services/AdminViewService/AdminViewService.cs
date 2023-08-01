using Microsoft.Extensions.Hosting;
using tourismBigbang.Models;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;
using tourismBigBang.Repository.AdminViewRepo;

namespace tourismBigBang.Services.AdminViewService
{
    public class AdminViewService:IAdminViewService
    {
        private readonly IAdminViewRepo _adminViewRepo;
        public AdminViewService(IAdminViewRepo adminViewRepo)
        {
            _adminViewRepo = adminViewRepo;
        }
        public async Task<UserInfo> BeforeApproval(UserInfo userInfo)
        {
            var post= await _adminViewRepo.PostAgentApproval(userInfo);
            if (post == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return post;
        }
        public async Task<AgentApproval> AfterApproved (AgentApproval agentApproval)
        {
            var post=await _adminViewRepo.PostAgentApproved(agentApproval);
            if (post == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return post;
        }
        public async Task<List<AgentApproval>> GetForApproval()
        {
            var get= await _adminViewRepo.GetApproval();
            if (get == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return get;
        }
    }
}
