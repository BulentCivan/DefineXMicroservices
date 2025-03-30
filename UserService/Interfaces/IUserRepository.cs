using DefineX.Services.UserService.Models;
using Microsoft.AspNetCore.Identity;
using UserService.Dtos;

namespace UserService.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(RegisterDto userDto);
        Task<string> AuthenticateUserAsync(string email, string password);
    }
}
