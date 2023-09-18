using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFileService
    {
        Files GetFileById(Guid id);
        void InsertImage(IFormFile file,Guid id);
    }
}
