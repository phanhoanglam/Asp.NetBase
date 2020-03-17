using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyProject.Application.Services.User;
using MyProject.Application.Services.User.Dto;
using MyProject.Core.Entity;
using MyProject.Web.Controllers.ControllerBase;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;

        private IConfiguration _config;

        public UserController(UserManager<AppUser> userManager, IConfiguration config, IUserService userService)
        {
            _userManager = userManager;
            _config = config;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserDto input)
        {
            var result = await _userService.Register(input);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("Post")]
        public string post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claims = identity.Claims.ToList();
            var username = claims[0].Value;
            return "Welcome to : " + username;
        }

        [HttpPost("Authentica")]
        public async Task<IActionResult> Authentica(AuthenticaDto input)
        {
            var user = await _userManager.FindByEmailAsync(input.UserNameOrEmail);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, input.Password))
                {
                    var tokenStr = GenerateJSONWebToken(user);
                    return Ok(tokenStr);
                }
                else
                {
                    return BadRequest("Login invalid !!!");
                }
            }
            return BadRequest("Email does not exist !!!");
        }

        private string GenerateJSONWebToken(AppUser input)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, input.UserName),
                new Claim(JwtRegisteredClaimNames.Email, input.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var enCodeToKen = new JwtSecurityTokenHandler().WriteToken(token);
            return enCodeToKen;
        }
    }
}