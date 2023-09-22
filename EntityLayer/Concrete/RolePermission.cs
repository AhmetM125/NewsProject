using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RolePermission
    {
        [ForeignKey("Role")]
        public Int16 RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Permission")]
        public Int16 PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
