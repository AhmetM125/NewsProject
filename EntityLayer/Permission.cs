using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Permission
    {
        [Key]
        public short Id { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "Error")]
        public string Title { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }


    }
}
