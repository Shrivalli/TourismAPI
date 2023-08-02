using tourismBigBang.Models.View_Model;

namespace tourismBigBang.Services.TokenService
{
    public interface ITokenService
    {
        public string GenerateToken(UserDTO user);

    }
}
