using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PermissionManager : IPermissionService
    {
        private readonly IPermissionDal PermissionDal;
        public PermissionManager(IPermissionDal permissionDal)
        {
            PermissionDal = permissionDal;
        }

        public ICollection<Permission> GetAllPermission()
        {
            return PermissionDal.List();
        }

        public Permission GetPermission(int id) => PermissionDal.Get(x => x.Id == id);

        public void DeletePermission(Permission permission)
        {
            PermissionDal.Delete(permission);
        }

        public void CreatePermission(Permission permission)
        {
            PermissionDal.Insert(permission);
        }

        public void UpdatePermission(Permission permission)
        {
            PermissionDal.Update(permission);
        }
    }
}
