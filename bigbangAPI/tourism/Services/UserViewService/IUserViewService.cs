using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models.Dto;
using tourismBigBang.Models.View_Model;

namespace tourismBigBang.Services.UserViewService
{
    public interface IUserViewService
    {
        Task<List<PlanDTO>> GetPlans();
        Task<List<OverallPackage>> GetPackageDetails(int placeId );
    }
}
