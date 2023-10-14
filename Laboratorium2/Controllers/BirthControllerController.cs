using Laboratorium2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium2.Controllers
{
    public class BirthControllerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Result(BirthCalculator model)
        {
            if (!model.IsValid())
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}
