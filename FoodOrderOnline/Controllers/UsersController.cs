using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FoodOrderOnline.DTO;
using FoodOrderOnline.Services.Imp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FoodOrderOnline.Controllers
{
    [Route("[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UsersServices _usersServices;

        public UsersController(IOptions<JwtSettings> _jwtSettingsAccesser, UsersServices userServices)
        {
            _jwtSettings = _jwtSettingsAccesser.Value;
            _usersServices = userServices;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Login([FromBody]UserDTO userDto)
        {
            if (ModelState.IsValid)
            {
                var user = _usersServices.Login(userDto.account_name,userDto.account_password);
                if (user == null)
                {
                    return BadRequest();
                }
                var userIsadmin = user.isadmin;

                var claim = new Claim[] {
                     new Claim(ClaimTypes.Name,user.id.ToString()),
                     new Claim(ClaimTypes.Role,userIsadmin ? "Admin" : "User")
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, claim, DateTime.Now, DateTime.Now.AddDays(1), creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }
            return BadRequest();
            //return View();
        }

        public IActionResult Register([FromBody]UserDTO userDto )
        {
            //注册完重定向回登陆页面
            _usersServices.Register(userDto.phonenumber,userDto.account_name,userDto.account_password);

            return View();
        }
    }
}