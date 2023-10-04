using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    public class UserRole
    {
        [ExplicitKey]
        public Guid Id { get; set; }

        [ForeignKey("Admin")]
        public Guid? UserId { get; set; }
        public virtual Admin Admin { get; set; } 

        [ForeignKey("Role")]
        public short RoleId { get; set; }
        public Role Role { get; set; }
    }
}
