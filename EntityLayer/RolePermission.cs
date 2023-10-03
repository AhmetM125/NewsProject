
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Dapper.Contrib.Extensions.Table("RolePermissions")]
    public class RolePermission
    {
        [ForeignKey("Role")]
        public short RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Permission")]
        public short PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
