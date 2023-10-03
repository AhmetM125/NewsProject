

using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    [Table("Admins")]
    public class Admin
    {
        [Dapper.Contrib.Extensions.Key]
        public Guid User_Id { get; set; }


        [MaxLength(30, ErrorMessage = "Name should be less than 30 characters")]
        [Required]
        public string Name { get; set; } = default!;

        [MaxLength(30, ErrorMessage = "Surname should be less than 30 characters")]
        [Required]
        public string Surname { get; set; } = default!;

        [MaxLength(30, ErrorMessage = "Username should be less than 30 characters")]
        [Required]
        public string Username { get; set; } = default!;

        [MaxLength(30, ErrorMessage = "Password should be less than 30 characters")]
        [Required]
        public string Password { get; set; } = default!;
        //notmapped
        [Computed]
        public virtual ICollection<UserRole>? UserRoles { get; set; }


    }
}
