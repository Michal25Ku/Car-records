using Laboratorium3.Mappers;
using Laboratorium3.Models;
using Laboratorium3.Models.Services;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "admin")]
        public IActionResult AllOwners()
        {
            return View(_ownerService.FindAll());
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateOwner()
        {
            return View();
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _ownerService.Delete(id);
            return RedirectToAction("AllOwners");
        }

        [Authorize]
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

        [Authorize]
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
