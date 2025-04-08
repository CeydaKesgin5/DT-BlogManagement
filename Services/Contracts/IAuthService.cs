using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
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
