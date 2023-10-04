
using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    public class RolePermission
    {
        [ExplicitKey]
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Role")]
        public short RoleId { get; set; }
        public Role Role { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Permission")]
        public short PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
