using Library.BLL.Interfaces;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library.WEB.Controllers
{
    public class BrochureController : Controller
    {
        private readonly IService<BrochureViewModel> _brochureService;

        public BrochureController(IService<BrochureViewModel> brochureService)
        {
            _brochureService = brochureService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBrochures()
        {
            var data = _brochureService.GetItems().OrderByDescending(b => b.Name).Select(b => new
            {
                ID = b.Id,
                b.Name,
                TypeOfCover = b.TypeOfCover.ToString(),
                b.NumberOfPages,
            }).ToList();
            return Json(data);
        }

        public ActionResult AddBrochure()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBrochure(BrochureViewModel brochureViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _brochureService.Insert(brochureViewModel);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditBrochure(int id)
        {
            return View(_brochureService.GetItem(id));
        }

        [HttpPost]
        public ActionResult EditBrochure(int id, BrochureViewModel brochureViewModel)
        {
            try
            {
                _brochureService.Update(brochureViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrochure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var brochure = _brochureService.GetItem(id);
            if (brochure == null)
            {
                return NotFound();
            }
            _brochureService.Delete(id);
            return Ok(brochure);
        }
    }
}
