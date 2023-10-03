using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    [Dapper.Contrib.Extensions.Table("Permissions")]
    public class Permission
    {
        [Dapper.Contrib.Extensions.Key]
        public short Id { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "Error")]
        public string Title { get; set; } = default!;
        [Computed]
        public ICollection<RolePermission> RolePermission { get; set; }


    }
}
