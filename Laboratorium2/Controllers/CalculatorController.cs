using Laboratorium2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form() 
        {
            return View();
        }

        public IActionResult Result(Operators? op, [FromQuery(Name = "a")]double? a, [FromQuery(Name = "b")] double? b)
        {
            if (a == null || b == null || op == null)
            {
                return View("Error");
            }
            switch (op)
            {
                case Operators.ADD:
                    ViewData["op"] = a + b;
                    ViewBag.Result = a + " + " + b + " = " + ViewData["op"];
                    break;
                case Operators.SUM:
                    ViewData["op"] = a - b;
                    ViewBag.Result = a + " - " + b + " = " + ViewData["op"];
                    break;
                case Operators.MUL:
                    ViewData["op"] = a * b;
                    ViewBag.Result = a + " * " + b + " = " + ViewData["op"];
                    break;
                case Operators.DIV:
                    if (b == 0)
                        return View("Error");

                    ViewData["op"] = a / b;
                    ViewBag.Result = a + " / " + b + " = " + ViewData["op"];
                    break;
                case Operators.POW:

                    ViewData["op"] = Math.Pow((double)a, (double)b);
                    ViewBag.Result = a + " ^ " + b + " = " + ViewData["op"];
                    break;
                case Operators.SQRT:

                    ViewData["op"] = Math.Pow((double)a, (double)(1 / b));
                    ViewBag.Result = a + " SQRT " + b + " = " + ViewData["op"];
                    break;
                default: return View("Error");
            }
            return View();
        }
    }
}
