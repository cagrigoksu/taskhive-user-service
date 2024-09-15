﻿using Microsoft.AspNetCore.Mvc;
using TaskHive_UserService.Models;

namespace TaskHive_UserService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDataModel> GetUserByEmailAsync(string email);
        Task<UserProfileDataModel> GetUserProfileByIdAsync(int userId);
        void AddUser(UserDataModel user);
        Task<UserProfileDataModel> AddUserProfile(UserProfileDataModel profile);
        // StatusCodeResult EditUserProfile(UserProfileDataModel userProfile);
        // void DeleteUserAsync(int id);
        Task<bool> IsUserExistAsync(string email);
    }
}
