using Microsoft.AspNetCore.Mvc;
using TaskHive_UserService.Models;
using TaskHive_UserService.Models.Data;
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

        public async Task<UserProfileDataModel> GetUserProfileByUserIdAsync(int userId)
        {
            var user = await _userRepository.GetUserProfileByUserIdAsync(userId);

            return user;
        }

        public void AddUser(UserDataModel user)
        {
            _userRepository.AddUser(user);
        }

        public async Task<UserProfileDataModel> AddOrEditUserProfileAsync(UserProfileModel profile)
        {
            var result = await _userRepository.AddOrEditUserProfileAsync(profile);
            return result;
        }

        public async Task<UserDataModel> EditUserEmailAsync(UserModel user)
        {
            var result = await _userRepository.EditUserEmailAsync(user);
            return result;
        }
    }
}
