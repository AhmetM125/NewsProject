using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    public class UserRole
    {
        [ForeignKey("Admin")]
        public Guid? UserId { get; set; }
        public Admin Admin { get; set; } 

        [ForeignKey("Role")]
        public short RoleId { get; set; }
        public Role Role { get; set; }
    }
}
