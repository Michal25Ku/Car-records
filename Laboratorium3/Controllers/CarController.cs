using Laboratorium3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Laboratorium3.Controllers
{
    public class CarController : Controller
    {
        static Car testCar = new Car()
        {
            Id = 1,
            Model = "Felicia",
            Producer = "Skoda",
            EngineCapacity = "1.6",
            EnginePower = 90,
            EngineType = "Benzynowy",
            LicensePlateNumber = "KR 92L",
            Owner = new CarContactDetails()
            {
                FirstName = "Michal",
                LastName = "Kuciak",
                PhoneNumber = "+48193024765",
                Email = "michal@gmail.com"
            }
        };

        static Dictionary<int, Car> _cars = new Dictionary<int, Models.Car>() { { 1, testCar } };

        public IActionResult Index()
        {
            return View(_cars);
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
                int id = _cars.Keys.Count != 0 ? _cars.Keys.Max() : 0;
                car.Id = id + 1;
                _cars.Add(car.Id, car);

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
            if (_cars.Keys.Contains(id))
            {
                return View(_cars[id]);
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
                _cars[car.Id] = car;

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
            if (_cars.Keys.Contains(id))
            {
                return View(_cars[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _cars.Remove(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetailsCar(int id)
        {
            if (_cars.Keys.Contains(id))
            {
                return View(_cars[id]);
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
