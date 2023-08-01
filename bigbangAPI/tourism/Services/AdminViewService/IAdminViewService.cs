using tourismBigbang.Models;
using tourismBigBang.Models;

namespace tourismBigBang.Services.AdminViewService
{
    public interface IAdminViewService
    {
        Task<UserInfo> BeforeApproval(UserInfo userInfo);
        Task<AgentApproval> AfterApproved(AgentApproval agentApproval);
        Task<List<AgentApproval>> GetForApproval();
    }
}
