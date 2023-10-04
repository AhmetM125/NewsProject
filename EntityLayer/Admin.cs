

using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    [Table("dbo.Admins")]
    public class Admin
    {
        [ExplicitKey]
        public Guid User_Id { get; set; }

        public string Name { get; set; } = default!;

        public string Surname { get; set; } = default!;

        public string Username { get; set; } = default!;

        public string Password { get; set; } = default!;
        //notmapped
        [Computed]
        public virtual ICollection<UserRole>? UserRoles { get; set; }


    }
}
