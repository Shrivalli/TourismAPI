using Microsoft.AspNet.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using tourismBigbang.Context;
using tourismBigBang.Global_Exception;
using tourismBigBang.Models;
using tourismBigBang.Models.View_Model;

namespace tourismBigBang.Repository.UserTableRepo
{
    public class UserTableRepo:IUserTableRepo
    {
        private readonly TourismContext _context;
        public UserTableRepo(TourismContext context)
        {
            _context = context;
        }
        public async Task<UserInfo?> Add(UserInfo UserInfo)
        {
            try
            {
                var UserInfos = _context.UserInfos;
                var myUserInfo = await UserInfos.SingleOrDefaultAsync(u => u.Username == UserInfo.Username);
                if (myUserInfo == null)
                {
                    await _context.UserInfos.AddAsync(UserInfo);
                    await _context.SaveChangesAsync();
                    return UserInfo;
                }
                return null;
            }
            catch (Exception) { throw new Exception(CustomException.ExceptionMessages["Empty"]); }
        }

        public async Task<UserInfo?> Delete(UserDTO UserInfoDTO)
        {
            try
            {
                var UserInfos = _context.UserInfos;
                var myUserInfo = UserInfos.SingleOrDefault(u => u.Username == UserInfoDTO.Username);
                if (myUserInfo != null)
                {
                    _context.UserInfos.Remove(myUserInfo);
                    await _context.SaveChangesAsync();
                    return myUserInfo;
                }
                return null;
            }
            catch (Exception) { throw new Exception(CustomException.ExceptionMessages["Empty"]); }
        }

        public async Task<UserInfo?> GetValue(UserDTO UserInfoDTO)
        {
            try
            {
                var UserInfos = await GetAll();
                if (UserInfos != null)
                {
                    var UserInfo = UserInfos.FirstOrDefault(u => u.Username == UserInfoDTO.Username);
                    if (UserInfo != null)
                    {
                        return UserInfo;
                    }
                }
                return null;
            }
            catch (Exception) { throw new Exception(CustomException.ExceptionMessages["Empty"]); }
        }

        public async Task<List<UserInfo>?> GetAll()
        {
            try
            {
                var UserInfos = await _context.UserInfos.ToListAsync();
                if (UserInfos != null)
                {
                    return UserInfos;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception(CustomException.ExceptionMessages["Empty"]);
            }
        }

        public async Task<UserInfo?> Update(UserInfo UserInfo)
        {
            try
            {
                var UserInfos = await GetAll();
                if (UserInfos != null)
                {
                    var NewUserInfo = UserInfos.FirstOrDefault(u => u.Username == UserInfo.Username);
                    if (NewUserInfo != null)
                    {
                        _context.UserInfos.Update(NewUserInfo);
                        await _context.SaveChangesAsync();
                        return NewUserInfo;
                    }
                }
                return null;


            }
            catch (Exception) { throw new Exception(CustomException.ExceptionMessages["Empty"]); }

        }
    }
}

