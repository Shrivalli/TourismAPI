using tourismBigBang.Models.View_Model;

namespace tourismBigBang.Services.UserTableService
{
    public interface IUserTableService
    {
        Task<UserDTO> Login(UserDTO userDTO);
        Task<UserDTO> Register(UserRegisterDTO registerDTO);
        Task<UserDTO> Update(UserRegisterDTO user);
        Task<bool> UpdatePassword(UserDTO userDTO);
    }
}
