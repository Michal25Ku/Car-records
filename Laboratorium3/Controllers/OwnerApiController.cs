using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium3.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerApiController : ControllerBase
    {
        private readonly CarDbContext _context;

        public OwnerApiController(CarDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFiltered(string filter)
        {
            return Ok(_context.Owners
                .Where(o => o.LastName.ToLower().StartsWith(filter.ToLower()))
                .Select(o => new { o.LastName, o.Id})
                .ToList());
        }
    }
}
