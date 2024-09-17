using Microsoft.AspNetCore.Mvc;
using TaskHive_UserService.Models;
using TaskHive_UserService.Models.Data;

namespace TaskHive_UserService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDataModel> GetUserByUserIdAsync(int id);
         Task<UserDataModel> GetUserByEmailAsync(string email);
        Task<UserProfileDataModel> GetUserProfileByUserIdAsync(int userId);
        void AddUser(UserDataModel user);
        Task<UserProfileDataModel> AddOrEditUserProfileAsync(UserProfileModel profile);
        Task<UserDataModel> EditUserEmailAsync(UserModel user);
        Task<bool> IsUserExistAsync(string email);
    }
}
