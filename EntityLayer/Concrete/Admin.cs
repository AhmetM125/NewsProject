using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public Guid User_Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Surname { get; set; } = default!;
        [Required]
        public string Username { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;

    }
}
