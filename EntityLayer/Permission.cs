using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        public short Id { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "Error")]
        public string Title { get; set; } = default!;
        public ICollection<RolePermission> RolePermission { get; set; }


    }
}
