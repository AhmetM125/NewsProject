using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    public class FileController : Controller
    {
        FileManager fm = new FileManager(new EfFilesDal());
        public IActionResult Index()
        {
            return View();
        }

        [Route("GetImage/{id}")]
        public FileResult GetImage(Guid id)
        {
            var value = fm.GetFileById(id);
            return File(value.Content, value.ContentType);
        }
    }
}
