using Microsoft.AspNetCore.Mvc;
using Problem1.Models;

namespace Problem1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public OrdersController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _context.Orders
                                 .Where(o => o.EmployeeId == 5)
                                 .ToList();

            return Ok(orders);
        }
    }
}