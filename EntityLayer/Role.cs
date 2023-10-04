using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = default!;

        [Computed]
        public ICollection<UserRole> UserRoles { get; set; }
        [Computed]
        public ICollection<RolePermission> RolePermissions { get; set; }


    }
}
