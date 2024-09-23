using System.ComponentModel.DataAnnotations;

namespace TaskHive_UserService.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
