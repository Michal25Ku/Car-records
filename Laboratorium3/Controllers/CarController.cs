using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View(_carService.FindAll());
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult EditCar(int id)
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
                return View();
            }
        }

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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _carService.Delete(id);
            return RedirectToAction("Index");
        }

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
