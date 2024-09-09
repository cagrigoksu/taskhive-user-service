﻿using Microsoft.AspNetCore.Mvc;
using TaskHive_UserService.Models;

namespace TaskHive_UserService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDataModel> GetUserAsync(string email);
        Task<UserProfileDataModel> GetUserProfileAsync(int userId);
        void AddUser(UserDataModel user);
        StatusCodeResult AddUserProfile(UserProfileDataModel profile);
        StatusCodeResult EditUserProfile(UserProfileDataModel userProfile);
        void DeleteUserAsync(int id);
        Task<bool> IsUserExistAsync(string email);
    }
}
