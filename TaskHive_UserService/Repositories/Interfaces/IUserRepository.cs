using Microsoft.AspNetCore.Mvc;
using TaskHive_UserService.Models;

namespace TaskHive_UserService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDataModel> GetUserByEmailAsync(string email);
        Task<UserProfileDataModel> GetUserProfileByUserIdAsync(int userId);
        void AddUser(UserDataModel user);
        Task<UserProfileDataModel> AddUserProfile(UserProfileDataModel profile);
        Task<UserProfileDataModel> EditUserProfile(UserProfileDataModel userProfile);
        Task<bool> IsUserExistAsync(string email);
    }
}
