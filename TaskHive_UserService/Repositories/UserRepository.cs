using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TaskHive_UserService.Models;
using TaskHive_UserService.Models.Data;
using TaskHive_UserService.Repositories.Interfaces;

namespace TaskHive_UserService.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserDataModel> GetUserByEmailAsync(string email)
        {
            var user = _db.Users.FirstOrDefaultAsync(x => x.Email == email && x.IsDeleted == false);

            return await user;
        }

        public async Task<UserDataModel> GetUserByUserIdAsync(int userId){
            var user = _db.Users.FirstOrDefaultAsync(x => x.Id == userId && x.IsDeleted == false);
            return await user;
        }

        public async Task<UserProfileDataModel> GetUserProfileByUserIdAsync(int userId)
        {
            var profile = _db.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId && x.IsDeleted == false);

            return await profile;
        }

        public void AddUser(UserDataModel user)
        {
            user.LogOnDate = DateTime.Now;
            _db.Add(user);
            _db.SaveChanges();
        }

        public async Task<UserProfileDataModel> AddOrEditUserProfileAsync(UserProfileModel userProfile)
        {
            try
            {   
                //get current user profile
                var currentUserProfile =  await GetUserProfileByUserIdAsync(userProfile.UserId);

                if(currentUserProfile != null)
                {
                    currentUserProfile.Name = userProfile.Name;
                    currentUserProfile.Surname = userProfile.Surname;
                    currentUserProfile.PhoneNumber = userProfile.PhoneNumber;
                    currentUserProfile.Department = userProfile.Department;
                    currentUserProfile.Role = userProfile.Role;

                    currentUserProfile.LastUpdateDate = DateTime.Now;
                    _db.Update(currentUserProfile);
                    await _db.SaveChangesAsync();

                    return currentUserProfile;
                }
                else
                {
                    
                    // get user by id
                    var user = await GetUserByUserIdAsync(userProfile.UserId);

                    var userToAdd = new UserProfileDataModel()
                    {
                        UserId = userProfile.UserId,
                        Name = userProfile.Name,
                        Surname = userProfile.Surname,
                        PhoneNumber = userProfile.PhoneNumber,
                        Department = userProfile.Department,
                        Role = userProfile.Role,
                        CreateDate = DateTime.Now,
                        LastUpdateDate = DateTime.Now
                    };

                   
                    _db.Add(userToAdd);
                    await _db.SaveChangesAsync();

                    currentUserProfile =  await GetUserProfileByUserIdAsync(userProfile.UserId);
                    
                    return currentUserProfile;
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

       public async Task<UserDataModel> EditUserEmailAsync(UserModel user)
        {
            try
            {
                // get current record on db
                var data = await _db.Users.FirstAsync(x => x.Id == user.Id);

                if (data != null)
                {
                    data.Email = user.Email;
                    //TODO: add lastupdate column here and EF.                    

                    _db.Update(data);
                    await _db.SaveChangesAsync();
                }

                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        } 

        public async Task<bool> IsUserExistAsync(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user != null;
        }
    }
}
