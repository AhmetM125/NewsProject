using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    [Dapper.Contrib.Extensions.Table("Roles")]
    public class Role
    {
        [Dapper.Contrib.Extensions.Key]
        public short Id { get; set; }


        [Required]
        [MaxLength(30, ErrorMessage = "Error")]
        public string Title { get; set; } = default!;

        //
        [Computed]
        public ICollection<UserRole> UserRoles { get; set; }
        [Computed]
        public ICollection<RolePermission> RolePermissions { get; set; }


    }
}
