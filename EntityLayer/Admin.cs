

using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    [Table("dbo.Admins")]
    public class Admin
    {
        [ExplicitKey]
        public Guid User_Id { get; set; }

     //   [MaxLength(30, ErrorMessage = "Name should be less than 30 characters")]
     //   [Required]
        public string Name { get; set; } = default!;

       /* [MaxLength(30, ErrorMessage = "Surname should be less than 30 characters")]
        [Required]*/
        public string Surname { get; set; } = default!;
/*
        [MaxLength(30, ErrorMessage = "Username should be less than 30 characters")]
        [Required]*/
        public string Username { get; set; } = default!;

      //  [MaxLength(30, ErrorMessage = "Password should be less than 30 characters")]
     //   [Required]
        public string Password { get; set; } = default!;
        //notmapped
        [Computed]
        public virtual ICollection<UserRole>? UserRoles { get; set; }


    }
}
