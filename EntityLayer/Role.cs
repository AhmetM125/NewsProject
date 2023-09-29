using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
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
