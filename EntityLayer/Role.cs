using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public short Id { get; set; }


        [Required]
        [MaxLength(30, ErrorMessage = "Error")]
        public string Title { get; set; } = default!;

        //
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }


    }
}
