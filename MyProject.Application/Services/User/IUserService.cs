using Microsoft.AspNetCore.Identity;
using MyProject.Application.Services.User.Dto;
using System.Threading.Tasks;

namespace MyProject.Application.Services.User
{
    public interface IUserService
    {
        Task<IdentityResult> Register(CreateUserDto input);
    }
}