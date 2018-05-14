using Library.BLL.Interfaces;
using Library.BLL.Service;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly AdditionalService _additionalService;
        private readonly IService<BookViewModel> _bookService;
        private readonly IService<PublicationHouseViewModel> _houseService;

        public BookController(IService<BookViewModel> bookService, IService<PublicationHouseViewModel> houseService, AdditionalService additionalService)
        {
            _additionalService = additionalService;
            _bookService = bookService;
            _houseService = houseService;
        }

        [HttpGet]
        public IEnumerable<BookViewModel> GetBooks()
        {
            var books = _bookService.GetItems().ToList();
            return books;
        }

        [HttpGet("{id}")]
        public IActionResult GetBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = _bookService.GetItem(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /*public ActionResult GetBooks()
        {
            var data = _bookService.GetItems().OrderByDescending(b => b.Name).Select(b => new
            {
                ID = b.Id,
                b.Name,
                b.Author,
                b.YearOfPublishing,
                PublicationHouses = _additionalService.GetPublicationHouseNames(b.PublicationHouses)
            }).ToList();
            return Json(data);
        }*/

        public ActionResult GetPublicationHouses()
        {
            var data = _houseService.GetItems().OrderByDescending(p => p.Name).Select(p => new
            {
                p.Id,
                p.Name
            }).ToList();
            return Json(data);
        }

        /*public ActionResult GetBookPublicationHouses(int bookId)
        {
            var book = _bookService.GetItem(bookId);
            var data = book.PublicationHouses.Select(p => p.PublicationHouseId).ToList();
            return Json(data);
        }*/

        [HttpPut("{id}")]
        public IActionResult PutBook([FromRoute] int id, [FromBody] BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }
            _bookService.Update(book);

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostBook([FromBody]BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Insert(book);
                return Ok(book);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook([FromRoute] int id)
        {
            var book = _bookService.GetItem(id);
            if (book != null)
            {
                _bookService.Delete(id);
            }
            return Ok(book);
        }
    }
}