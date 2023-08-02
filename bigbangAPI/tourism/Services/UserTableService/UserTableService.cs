using Microsoft.AspNet.Identity;
using System.Security.Cryptography;
using System.Text;
using tourismBigBang.Models;
using tourismBigBang.Models.View_Model;
using tourismBigBang.Repository.UserTableRepo;
using tourismBigBang.Services.TokenService;

namespace tourismBigBang.Services.UserTableService
{
    public class UserTableService:IUserTableService
    {
        private readonly IUserTableRepo _userTableRepo;
        private readonly ITokenService _tokenService;
        public UserTableService(IUserTableRepo userTableRepo, ITokenService tokenService)
        {
            _userTableRepo=userTableRepo;
            _tokenService = tokenService;
        }
        public async Task<UserDTO> Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = await _userTableRepo.GetValue(userDTO);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.Hashkey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.Id=userData.Id;
                user.Username = userData.Username;
                user.Email=userData.Email;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        public async Task<UserDTO> Register(UserRegisterDTO registerDTO)
        {
            UserDTO user = null;
            using (var hmac = new HMACSHA512())
            {
                registerDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.UserPassword));
                registerDTO.Hashkey = hmac.Key;
                var resultUser = await _userTableRepo.Add(registerDTO);
                if (resultUser != null)
                {
                    user = new UserDTO();
                    user.Username = resultUser.Username;
                    user.Role = resultUser.Role;
                    user.Token = _tokenService.GenerateToken(user);
                }
            }
            return user;
        }

        public async Task<UserDTO> Update(UserRegisterDTO user)
        {
            var users = await _userTableRepo.GetAll();
            UserInfo myUser = users.SingleOrDefault(u => u.Username == user.Username);
            if (myUser != null)
            {
                myUser.Username = user.Username;
                myUser.PhoneNumber = user.PhoneNumber;
                var hmac = new HMACSHA512();
                myUser.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
                myUser.Hashkey = hmac.Key;
                myUser.Role = user.Role;
                myUser.Email = user.Email;
                UserDTO userDTO = new UserDTO();
                userDTO.Username = myUser.Username;
                userDTO.Role = myUser.Role;
                userDTO.Token = _tokenService.GenerateToken(userDTO);
                var newUser = _userTableRepo.Update(myUser);
                if (newUser != null)
                {
                    return userDTO;
                }
                return null;
            }
            return null;
        }

        public async Task<bool> UpdatePassword(UserDTO userDTO)
        {
            UserInfo user = new UserInfo();
            var users = await _userTableRepo.GetAll();
            var myUser = users.SingleOrDefault(u => u.Username == userDTO.Username);
            if (myUser != null)
            {
                var hmac = new HMACSHA512();
                user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                user.Hashkey = hmac.Key;
                user.Username = myUser.Username;
                user.Role = myUser.Role;
                user.PhoneNumber = myUser.PhoneNumber;
                user.Email = myUser.Email;
                var newUser = _userTableRepo.Update(user);
                if (newUser != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

