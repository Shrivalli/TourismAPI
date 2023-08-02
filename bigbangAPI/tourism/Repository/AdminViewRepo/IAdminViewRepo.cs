using Microsoft.AspNetCore.Mvc;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.AdminViewRepo
{
    public interface IAdminViewRepo
    {
        Task<UserInfo> PostAgentApproval(UserInfo userInfo);
        Task<List<UserInfo>> GetAgentApproval();
        Task<UserInfo> UpdateAgentApproval(int id);
        Task<UserInfo> DeleteApproval(int id);
        Task<ImageGallery> PostImage([FromForm] ImageGallery gallery);
        Task<Place> PostPlaceImage([FromForm] Place place);
        Task<string> SaveImage(IFormFile imageFile);
    }
}
