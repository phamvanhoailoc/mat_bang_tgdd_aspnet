using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI_project_banhang.Modules.M_User.Models;
using WebAPI_project_banhang.Modules.M_User.Services;
using WebAPI_project_banhang.Modules.M_User.ViewModels;
using WebAPI_project_banhang.Modules.M_Users.ViewModels;

namespace WebAPI_project_banhang.Modules.M_User.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //https://localhost:44389/api/users/register
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterViewModel registerViewModel)
        {
            try
            {
                User user = await _userService.RegisterUser(registerViewModel);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        //https://localhost:44389/api/users/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginViewModel loginViewModel)
        {
            try
            {
                string user = await _userService.LoginUser(loginViewModel);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        
    }
}
