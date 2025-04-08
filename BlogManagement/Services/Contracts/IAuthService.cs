using BlogManagement.DTOs;
using BlogManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogManagement.Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityUser> GetOneUser(string userName);
        Task<IdentityResult> CreateUser(UserDtoForCreation user);
        Task<IdentityResult> DeleteOneUser(string userName);
    }
}
