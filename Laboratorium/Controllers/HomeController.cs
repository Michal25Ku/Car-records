using Laboratorium.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium.Controllers
{
    public enum Operators
    {
        UNKNOW, ADD, SUM, MUL, DIV, POW, SQRT
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Calculator(Operators op, double? a, double? b)
        {
            if(a == null || b == null)
            {
                return View("Error");
            }
            switch(op)
            {
                case Operators.ADD:
                    ViewData["op"] = a + b;
                    break;
                case Operators.SUM:
                    ViewData["op"] = a - b;
                    break;
                case Operators.MUL:
                    ViewData["op"] = a * b;
                    break;
                case Operators.DIV:
                    if(b == 0)
                        return View("Error");

                    ViewData["op"] = a / b;
                    break;
                case Operators.POW:

                    ViewData["op"] = Math.Pow((double)a, (double)b);
                    break;
                case Operators.SQRT:

                    ViewData["op"] = Math.Pow((double)a, (double)(1/b));
                    break;
                default: return View("Error");
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}