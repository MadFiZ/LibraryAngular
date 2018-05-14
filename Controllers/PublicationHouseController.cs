using Library.BLL.Interfaces;
using Library.BLL.Service;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.WEB.Controllers
{
    public class PublicationHouseController : Controller
    {
        private readonly IService<PublicationHouseViewModel> _houseService;
        private readonly IService<BookViewModel> _bookService;
        private readonly AdditionalService _additionalService;

        public PublicationHouseController(IService<PublicationHouseViewModel> houseService, IService<BookViewModel> bookService, AdditionalService additionalService)
        {
            _houseService = houseService;
            _bookService = bookService;
            _additionalService = additionalService;
        }

        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult GetPublicationHouses()
        {
            var data = _houseService.GetItems().OrderByDescending(p => p.Name).Select(P => new
            {
                ID = P.Id,
                P.Name,
                P.Adress,
                Books = _additionalService.GetBooksNames(P.Books)
            }).ToList();
            return Json(data);
        }*/

        public ActionResult AddPublicationHouse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPublicationHouse(PublicationHouseViewModel PublicationHouseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _houseService.Insert(PublicationHouseViewModel);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPublicationHouse(int id)
        {
            return View(_houseService.GetItem(id));
        }

        [HttpPost]
        public ActionResult EditPublicationHouse(PublicationHouseViewModel PublicationHouseViewModel)
        {
            try
            {
                _houseService.Update(PublicationHouseViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublicationHouse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PublicationHouseViewModel publicationHouse = _houseService.GetItem(id);
            if (publicationHouse == null)
            {
                return NotFound();
            }
            _houseService.Delete(id);
            return Ok(publicationHouse);
        }
    }
}

