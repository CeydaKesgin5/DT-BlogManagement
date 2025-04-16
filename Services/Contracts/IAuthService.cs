using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<IdentityUser> GetAllUsers();
        Task<IdentityUser> GetOneUser(string id);
        Task<IdentityResult> CreateUser(UserDtoForCreation user);
        Task Update(UserDtoForUpdate userDto);
        Task<IdentityResult> DeleteOneUser(string id);
        Task<UserDtoForUpdate> GetOneUserForUpdate(string userName);

    }
}
