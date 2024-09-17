using System.ComponentModel.DataAnnotations;

namespace TaskHive_UserService.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}