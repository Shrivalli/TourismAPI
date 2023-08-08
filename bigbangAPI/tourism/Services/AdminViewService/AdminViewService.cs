using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Serilog;
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
            var post= await _adminViewRepo.PostAgentApproval(userInfo) ?? throw new Exception(CustomException.ExceptionMessages["Empty"]);
            return post;
        }
        public async Task<List<UserInfo>> Approval()
        {
            var get = await _adminViewRepo.GetAgentApproval()?? throw new Exception(CustomException.ExceptionMessages["Empty"]);
            return get;
        }
        public async Task<UserInfo> ApprovedAgent(int id)
        {
            var approved= await _adminViewRepo.UpdateAgentApproval(id) ?? throw new Exception(CustomException.ExceptionMessages["NoId"]);
            return approved;
        }
        public async Task<UserInfo> RejectApproval(int id)
        {
            var reject= await _adminViewRepo.DeleteApproval(id) ?? throw new Exception(CustomException.ExceptionMessages["NoId"]);
            return reject;
        }
        public async Task<ImageGallery> PostImage([FromForm] ImageGallery gallery)
        {
            if (gallery == null)
            {
                Log.Error("invalid file in image gallery");
                throw new Exception("Invalid file");
            }
            var item = await _adminViewRepo.PostImage(gallery);
            if (item == null)
            {
                Log.Error("PostImage is null");
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return item;
        }
        public async Task<Place> PostPlaceImage([FromForm] Place place)
        {
            if (place == null)
            {
                Log.Error("PostPlaceImage is null");
                throw new Exception("Invalid file");
            }
            var item = await _adminViewRepo.PostPlaceImage(place) ?? throw new Exception(CustomException.ExceptionMessages["Empty"]);
            return item;
        }

    }
}
