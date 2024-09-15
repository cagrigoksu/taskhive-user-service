using Microsoft.AspNetCore.Mvc;
using TaskHive_UserService.Models;
using TaskHive_UserService.Repositories.Interfaces;
using TaskHive_UserService.Services.Interfaces;

namespace TaskHive_UserService.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDataModel> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            return user;
        }

        public async Task<bool> IsUserExistAsync(string email)
        {
            return await _userRepository.IsUserExistAsync(email);
        }

        public async Task<UserProfileDataModel> GetUserProfileByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserProfileByIdAsync(userId);

            return user;
        }

        public void AddUser(UserDataModel user)
        {
            _userRepository.AddUser(user);
        }

        public async Task<UserProfileDataModel> AddUserProfile(UserProfileDataModel profile)
        {
            var result = await _userRepository.AddUserProfile(profile);
            return result;
        }

        // public StatusCodeResult EditUserProfile(UserProfileDataModel userProfile)
        // {
        //     var result = _userRepository.EditUserProfile(userProfile);

        //     return result;

        // }

        // public void DeleteUser(int id)
        // {
        //     _userRepository.DeleteUserAsync(id);
        // }
    }
}
