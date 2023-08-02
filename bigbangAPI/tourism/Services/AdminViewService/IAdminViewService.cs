using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models;

namespace tourismBigBang.Services.AdminViewService
{
    public interface IAdminViewService
    {
        Task<UserInfo> BeforeApproval(UserInfo userInfo);
        Task<List<UserInfo>> Approval();
        Task<UserInfo> ApprovedAgent(int id);
        Task<UserInfo> RejectApproval(int id);
        Task<ImageGallery> PostImage([FromForm] ImageGallery gallery);
        Task<Place> PostPlaceImage([FromForm] Place place);
    }
}
