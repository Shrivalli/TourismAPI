using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tourismBigbang.Context;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.Identity;
using tourismBigBang.Models;
using tourismBigBang.Services.UserTableService;
using static System.Runtime.InteropServices.JavaScript.JSType;
using tourismBigBang.Models.View_Model;

namespace tourismBigbang.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserTableService _userTableService;
        public UserInfoController (IUserTableService userTableService)
        {
            _userTableService=userTableService;
        }

        [ProducesResponseType(typeof(UserInfo), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(UserRegisterDTO userRegisterDTO)
        {
            try
            {
                UserDTO user = await _userTableService.Register(userRegisterDTO);
                if (user == null)
                    return BadRequest( "Registration Not Successful");
                return Created("User Registered", user);
            }
            catch (Exception ise)
            {
                return BadRequest( ise.Message);
            }
        }

        [ProducesResponseType(typeof(UserInfo), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPost]
        public async Task<ActionResult<UserDTO>> LogIN(UserDTO userDTO)
        {
            try
            {
                UserDTO user = await _userTableService.Login(userDTO);
                if (user == null)
                    return BadRequest("Invalid Username or Password");
                return Ok(user);
            }
            catch (Exception ise)
            {
                return BadRequest( ise.Message);
            }
        }

        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update(UserRegisterDTO user)
        {
            try
            {
                var myUser = await _userTableService.Update(user);
                if (myUser == null)
                    return NotFound( "Unable to Update");
                return Created("User Updated Successfully", myUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]//Success Response
        [ProducesResponseType(StatusCodes.Status404NotFound)]//Failure Response
        [HttpPut]
        public async Task<ActionResult<string>> Update_Password(UserDTO user)
        {
            try
            {
                bool myUser = await _userTableService.UpdatePassword(user);
                if (myUser)
                    return NotFound("Unable to Update Password");
                return Ok("Password Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
