﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
	public class EfAdminDal : GenericRepository<Admin>, IAdminDal
	{
	}
}
