using Microsoft.AspNetCore.Mvc;
using TaskHive_UserService.Models;
using TaskHive_UserService.Models.Data;

namespace TaskHive_UserService.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDataModel> GetUserByEmailAsync(string email);
        Task<bool> IsUserExistAsync(string email);
        void AddUser(UserDataModel user);
        Task<UserProfileDataModel> GetUserProfileByUserIdAsync(int userId);
        Task<UserProfileDataModel> AddOrEditUserProfileAsync(UserProfileModel profile);
        Task<UserDataModel> EditUserEmailAsync(UserModel user);
    }
}
