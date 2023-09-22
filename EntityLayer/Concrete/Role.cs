using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Role
    {
        [Key]
        public Int16 Id { get; set; }
       

        [Required]
        [MaxLength(30, ErrorMessage = "Error")]

        public string Title { get; set; }

        public ICollection<UserRole> UserRoles { get; set;}

    }
}
