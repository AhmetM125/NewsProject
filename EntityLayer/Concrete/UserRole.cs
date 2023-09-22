using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserRole
    {
        [ForeignKey("Admin")]
        public Guid? UserId { get; set; }
        public Admin Admin { get; set; }

        [ForeignKey("Role")]
        public Int16 RoleId { get; set; }
        public Role Role { get; set; }
    }
}
