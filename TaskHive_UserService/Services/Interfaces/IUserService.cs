using Microsoft.AspNetCore.Mvc;
using TaskHive_UserService.Models;

namespace TaskHive_UserService.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDataModel> GetUserByEmailAsync(string email);
        Task<bool> IsUserExistAsync(string email);
        Task<UserProfileDataModel> GetUserProfileByUserIdAsync(int userId);
        void AddUser(UserDataModel user);
        Task<UserProfileDataModel> AddUserProfile(UserProfileDataModel profile);
        Task<UserProfileDataModel> EditUserProfile(UserProfileDataModel userProfile);
    }
}
