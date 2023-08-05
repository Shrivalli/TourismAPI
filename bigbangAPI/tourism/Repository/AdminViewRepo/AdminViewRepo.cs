using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using tourismBigbang.Context;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;

namespace tourismBigBang.Repository.AdminViewRepo
{
    public class AdminViewRepo:IAdminViewRepo
    {
        private readonly TourismContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminViewRepo(TourismContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
        public async Task<List<UserInfo>> GetAgentApproval()
        {
            var get= await _context.UserInfos.Where(s=>s.IsActive==false &&s.Role=="Agent").ToListAsync();
            if(get== null)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
            return get;
        }
        public async Task<UserInfo> UpdateAgentApproval(int id)
        {
            var update = await _context.UserInfos.FindAsync(id) ?? throw new Exception(CustomException.ExceptionMessages["NoId"]);
            update.IsActive = true;
            await _context.SaveChangesAsync();
            return update;
        }
        public async Task<UserInfo> DeleteApproval(int id)
        {
            var delete = await _context.UserInfos.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception(CustomException.ExceptionMessages["NoId"]);
            _context.UserInfos.Remove(delete);
            await _context.SaveChangesAsync();
            return delete;
        }
        public async Task<ImageGallery> PostImage([FromForm] ImageGallery gallery)
        {
            if (gallery == null)
            {
                throw new ArgumentException("Invalid file");
            }

            gallery.ImageName = await SaveImage(gallery.GalleryImage);
            _context.imageGalleries.Add(gallery);
            await _context.SaveChangesAsync();
            return gallery;
        }

        public async Task<Place> PostPlaceImage([FromForm] Place place)
        {
            if (place == null)
            {
                throw new ArgumentException("Invalid file");
            }

            place.ImageName = await SaveImage(place.PlaceImage);
            _context.Places.Add(place);
            await _context.SaveChangesAsync();
            return  place;
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot/Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
