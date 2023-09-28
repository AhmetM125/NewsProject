﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfFilesDal : GenericRepository<Files>, IFilesDal
    {
        public EfFilesDal(NEUContext context) : base(context)
        {
        }
    }
}
