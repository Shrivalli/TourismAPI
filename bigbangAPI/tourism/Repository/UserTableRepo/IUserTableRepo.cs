using tourismBigBang.Models;
using tourismBigBang.Models.View_Model;

namespace tourismBigBang.Repository.UserTableRepo
{
    public interface IUserTableRepo
    {
        Task<UserInfo?> Add(UserInfo UserInfo);
        Task<UserInfo?> Delete(UserDTO UserInfoDTO);
        Task<UserInfo?> GetValue(UserDTO UserInfoDTO);
        Task<List<UserInfo>?> GetAll();
        Task<UserInfo?> Update(UserInfo UserInfo);
    }
}
