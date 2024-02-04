using Laboratorium3.Models;
using Laboratorium3.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Laboratorium3.Controllers
{
    [Authorize(Roles = "admin")]
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
            return View(_carService.FindAll());
        }

        [Authorize(Roles = "user")]
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

        [Authorize(Roles = "user")]
        [HttpPost]
        public IActionResult CreateCar(Models.Car car)
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

        [Authorize(Roles = "user")]
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

        [Authorize(Roles = "user")]
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

        [Authorize(Roles = "user")]
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

        [Authorize(Roles = "user")]
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
