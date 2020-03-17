using Microsoft.AspNetCore.Identity;
using MyProject.Core.Entity;
using System.Threading.Tasks;

namespace MyProject.Application.Services.User.Dto
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(CreateUserDto input)
        {
            var result = await _userManager.CreateAsync(new AppUser
            {
                UserName = input.UserName,
                Email = input.Email,
                PhoneNumber = input.Phone,
                Address = input.Address,
                Gender = input.Gender
            }, input.Password);

            return result;
        }
    }
}