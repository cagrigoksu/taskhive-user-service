using System.ComponentModel.DataAnnotations;

namespace TaskHive_UserService.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}