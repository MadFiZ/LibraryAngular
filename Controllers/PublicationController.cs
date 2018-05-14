using Library.BLL.Service;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.WEB.Controllers
{
    public class PublicationController : Controller
    {
        private readonly PublicationService _libraryService;

        public PublicationController(PublicationService publicationService)
        {
            _libraryService = publicationService;
        }

        [HttpGet]
        public IEnumerable<PublicationViewModel> GetBooks()
        {
            var data = _libraryService.GetPublications().ToList()
                ID = b.Id,
                b.Name,
                Type = b.GetType().Name.Replace("ViewModel", "")
            }).AsEnumerable();
            return Json(data);
        }

  
        {
            var books = _bookService.GetItems().ToList();
            return books;
        }
    }
}