using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    [Table("dbo.UserRole")]
    public class UserRole
    {
        [ExplicitKey]
        public Guid G_Id { get; set; }
        public Guid? UserId { get; set; }      
        public short RoleId { get; set; }

        [Computed]
        public Role Role { get; set; }

        [Computed]
        public virtual Admin Admin { get; set; }
    }
}
