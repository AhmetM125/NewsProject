using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Permission
    {
        [Key]
        public Int16 Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Error")]
        public string Title { get; set; }

        public ICollection<RolePermission> RolePermission { get; set; }


    }
}
