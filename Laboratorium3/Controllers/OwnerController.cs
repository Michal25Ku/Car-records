using Laboratorium3.Mappers;
using Laboratorium3.Models;
using Laboratorium3.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium3.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public IActionResult AllOwners()
        {
            return View(_ownerService.FindAll());
        }

        [HttpGet]
        public IActionResult CreateOwner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOwner(Owner owner)
        {
            if (ModelState.IsValid)
            {
                _ownerService.Add(owner);
                return RedirectToAction("AllOwners");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditOwner(int id)
        {
            if (_ownerService.FindById(id) is not null)
            {
                return View(_ownerService.FindById(id));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditOwner(Owner owner)
        {
            if (ModelState.IsValid)
            {
                _ownerService.Update(owner);
                return RedirectToAction("AllOwners");
            }
            else
            {
                return View(owner);
            }
        }

        [HttpGet]
        public IActionResult DeleteOwner(int id)
        {
            if (_ownerService.FindById(id) is not null)
            {
                return View(_ownerService.FindById(id));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _ownerService.Delete(id);
            return RedirectToAction("AllOwners");
        }

        [HttpGet]
        public IActionResult OwnersCars(int id)
        {
            if (_ownerService.FindById(id) is not null)
            {
                List<Car> cars = new List<Car>();
                foreach (var c in _ownerService.FindAllCarsForOwner(id))
                {
                    cars.Add(CarMapper.FromEntity(c));
                }

                return View(cars);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult OwnersCars()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AllOwners");
            }
            else
            {
                return View();
            }
        }
    }
}
