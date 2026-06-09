using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Problem1.Models;

namespace Problem1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CustomersController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet("{country}")]
        public IActionResult GetCustomers(string country)
        {
            var parameter =
                new SqlParameter("@Country", country);

            var customers = _context.Customers
                .FromSqlRaw(
                    "EXEC GetCustomersByCountry @Country",
                    parameter)
                .ToList();

            return Ok(customers);
        }
    }
}