
using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    [Table("dbo.RolePermissions")]
    public class RolePermission
    {
        [ExplicitKey]
        public Guid G_Id { get; set; }

        public short RoleId { get; set; }
        [Computed]
        public Role Role { get; set; }

        public short PermissionId { get; set; }
        [Computed]
        public Permission Permission { get; set; }
    }
}
