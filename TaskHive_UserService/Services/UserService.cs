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

        public async Task<UserDataModel> GetUserAsync(string email)
        {
            var user = await _userRepository.GetUserAsync(email);

            return user;
        }

        public async Task<bool> IsUserExistAsync(string email)
        {
            return await _userRepository.IsUserExistAsync(email);
        }

        public async Task<UserProfileDataModel> GetUserProfileAsync(int userId)
        {
            var user = await _userRepository.GetUserProfileAsync(userId);

            return user;
        }

        public void AddUser(UserDataModel user)
        {
            _userRepository.AddUser(user);
        }

        public StatusCodeResult AddUserProfile(UserProfileDataModel profile)
        {
            var result = _userRepository.AddUserProfile(profile);
            return result;
        }

        public StatusCodeResult EditUserProfile(UserProfileDataModel userProfile)
        {
            var result = _userRepository.EditUserProfile(userProfile);

            return result;

        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUserAsync(id);
        }
    }
}
