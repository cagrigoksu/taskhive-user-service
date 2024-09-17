using System.ComponentModel.DataAnnotations;

namespace TaskHive_UserService.Models.Data
{
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordSalt { get; set; } = null!;
        [Required] public string PasswordHash { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; }
        public int DeleteUser { get; set; }
    }
}