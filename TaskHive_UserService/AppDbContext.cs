using Microsoft.EntityFrameworkCore;
using TaskHive_UserService.Models.Data;

namespace TaskHive_UserService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserDataModel> Users { get; set; }

        public DbSet<UserProfileDataModel> UserProfiles { get; set; }

    }
}
