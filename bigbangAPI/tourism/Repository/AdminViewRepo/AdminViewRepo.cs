using Microsoft.EntityFrameworkCore;
using tourismBigbang.Context;
using tourismBigbang.Models;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.AdminViewRepo
{
    public class AdminViewRepo:IAdminViewRepo
    {
        private readonly TourismContext _context;
        public AdminViewRepo(TourismContext context)
        {
            _context = context;
        }
        public async Task<UserInfo> PostAgentApproval(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            await _context.UserInfos.AddAsync(userInfo);
            await _context.SaveChangesAsync();
            return userInfo;
        }
        public async Task<AgentApproval> PostAgentApproved(AgentApproval agentApproval)
        {
            if (agentApproval == null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            await _context.AgentApprovals.AddAsync(agentApproval);
            await _context.SaveChangesAsync();
            return agentApproval;
        }
        public async Task<List<AgentApproval>> GetApproval()
        {
            var get =await  _context.AgentApprovals.ToListAsync();
            if(get==null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return get;
        }
    }
}
