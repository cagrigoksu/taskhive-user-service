using System.ComponentModel.DataAnnotations;

namespace TaskHive_UserService.Models
{
    public class UserProfileDataModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastEditDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; }
        public int DeleteUser { get; set; }

    }
}
