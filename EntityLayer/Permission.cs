using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    public class Permission
    {
        [Key]
        public short Id { get; set; }


        public string Title { get; set; } = default!;
        [Computed]
        public ICollection<RolePermission> RolePermission { get; set; }


    }
}
