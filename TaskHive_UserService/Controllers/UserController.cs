using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TaskHive_UserService;
using TaskHive_UserService.Models;
using TaskHive_UserService.Services.Interfaces;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace UserMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IUserService? _userService;
        private readonly ISecurityService? _securityService;

        public UserController(IUserService? userService, ISecurityService? securityService)
        {
            _userService = userService;
            _securityService = securityService;
        }

        [HttpPost("login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn([FromForm] LoginModel loginModel)
        {
            //System.Diagnostics.Debug.WriteLine("XXX");
            Console.WriteLine("Login request received.");
            
            // get user
            var user = await _userService.GetUserByEmailAsync(loginModel.Email);

            if (user != null)
            {
                // hash password and compare with db
                var hashedPwd = _securityService.Hasher(loginModel.Password, user.PasswordSalt, Globals.HashIter);

                if (user.PasswordHash == hashedPwd) // validated user
                {
                    var result = new UserDataModel()
                    {
                        Id = user.Id,
                        Email = user.Email
                    };

                    return Ok(result);
                }

                return BadRequest();
            }

            return BadRequest();
        }
        
        [HttpPost("logon")]
        public async Task<IActionResult> LogOn([FromForm] LogonModel logonModel)
        {
            Console.WriteLine("Logon request received.");
            
            var isUserExist = await _userService.IsUserExistAsync(logonModel.Email);

            if (!isUserExist)
            {
                if (logonModel.Password == logonModel.PasswordConf)
                {
                    // generate salt and hash
                    var userSalt = _securityService.GenerateSalt();
                    var userHashedPwd = _securityService.Hasher(logonModel.Password, userSalt, Globals.HashIter);

                    var user = new UserDataModel()
                    {
                        Email = logonModel.Email,
                        PasswordSalt = userSalt,
                        PasswordHash = userHashedPwd
                    };

                    // save user
                    _userService.AddUser(user);

                    var userResult = await _userService.GetUserByEmailAsync(user.Email);

                    if (userResult != null)
                    {
                        return Ok(new UserDataModel()
                        {
                            Id = userResult.Id,
                            Email = userResult.Email
                        });
                    }
                }
            }

            return BadRequest();
        }

        [HttpGet("getUserByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail([FromForm] string email)
        {
            Console.WriteLine("GetUserByEmail request received.");
            var result = await _userService.GetUserByEmailAsync(email);

            if (result != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("addUserProfile")]
        public async Task<IActionResult> AddUserProfileAsync([FromForm] UserProfileDataModel userProfile)
        {
            Console.WriteLine("AddUserProfile request received.");
            var result = await _userService.AddUserProfile(userProfile);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("editUserProfile")]
        public async Task<IActionResult> EditUserProfileAsync([FromForm] UserProfileDataModel userProfile)
        {
            var result = await _userService.EditUserProfile(userProfile);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // [HttpGet("getUserProfileByIdAsync/{userId}")]
        // public async Task<IActionResult> GetUserProfileByIdAsync(int userId)
        // {
        //     var user = await _userService.GetUserProfileByIdAsync(userId);

        //     if (user == null)
        //     {
        //         return BadRequest();
        //     }

        //     return Ok(user);
        // }       

    }
}
