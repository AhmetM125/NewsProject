using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Admin : IdentityUser
    {
        [Key]
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
        [MaxLength(20, ErrorMessage = "20 Character Max")]
        public string Role { get; set; } = default!;

    }
}
