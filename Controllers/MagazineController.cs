using Library.BLL.Interfaces;
using Library.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Library.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/magazines")]
    public class MagazineController : Controller
    {
        private readonly IService<MagazineViewModel> _magazineService;

        public MagazineController(IService<MagazineViewModel> magazineService)
        {
            _magazineService = magazineService;
        }

        [HttpGet]
        public IEnumerable<MagazineViewModel> GetMagazines()
        {
            var magazines = _magazineService.GetItems().ToList();
            return magazines;
        }

        [HttpGet("{id}")]
        public IActionResult GetMagazine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var magazine = _magazineService.GetItem(id);

            if (magazine == null)
            {
                return NotFound();
            }

            return Ok(magazine);
        }


        [HttpPut("{id}")]
        public IActionResult PutMagazine([FromRoute] int id, [FromBody] MagazineViewModel magazine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != magazine.Id)
            {
                return BadRequest();
            }
            _magazineService.Update(magazine);

            return NoContent();
        }

        [HttpPost]
        public IActionResult PostMagazine([FromBody]MagazineViewModel magazine)
        {
            if (ModelState.IsValid)
            {
                _magazineService.Insert(magazine);
                return Ok(magazine);
            }
            return BadRequest(ModelState);
        }

    [HttpDelete("{id}")]
        public IActionResult DeleteMagazine([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MagazineViewModel magazine = _magazineService.GetItem(id);
            if (magazine == null)
            {
                return NotFound();
            }
            _magazineService.Delete(id);
            return Ok(magazine);
        }
    }
}