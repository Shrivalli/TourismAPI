using tourismBigbang.Models;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.AdminViewRepo
{
    public interface IAdminViewRepo
    {
        Task<UserInfo> PostAgentApproval(UserInfo userInfo);
        Task<AgentApproval> PostAgentApproved(AgentApproval agentApproval);
        Task<List<AgentApproval>> GetApproval();
    }
}
