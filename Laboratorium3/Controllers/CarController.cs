using Laboratorium3.Models;
using Laboratorium3.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Laboratorium3.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewData["Visit"] = Response.HttpContext.Items[LastVisitCookie.CookieName];
            return View(_carService.FindAll());
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateCar()
        {
            Car model = new Car();
            model.Owners = _carService
                .FindAllOwnersForVievModel()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.FirstName + ' ' + o.LastName})
                .ToList();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateCar(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(car);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateCarForCurrentOwner(int id)
        {
            Car model = new Car();
            model.Owners = _carService
                .FindAllOwnersForVievModel()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.FirstName + ' ' + o.LastName })
                .Where(o => int.Parse(o.Value) == id)
                .ToList();
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditCar(int id)
        {
            if (_carService.FindById(id) is not null)
            {
                Car model = _carService.FindById(id);
                model.Owners = _carService
                    .FindAllOwnersForVievModel()
                    .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.FirstName + ' ' + o.LastName })
                    .ToList();

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditCar(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Update(car);
                return RedirectToAction("Index");
            }
            else
            {
                return View(car.Id);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteCar(int id)
        {
            if (_carService.FindById(id) is not null)
            {
                return View(_carService.FindById(id));
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _carService.Delete(id);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult DetailsCar(int id)
        {
            if (_carService.FindById(id) is not null)
            {
                return View(_carService.FindById(id));
            }
            else
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DetailsCar()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
