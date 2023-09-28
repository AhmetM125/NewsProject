using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace M_News.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        public IActionResult Index() => View();

        [Route("GetImage/{id}")]
        public FileResult GetImage(Guid id)
        {
            var value = _fileService.GetFileById(id);
            return File(value.Content, value.ContentType);
        }
    }
}
