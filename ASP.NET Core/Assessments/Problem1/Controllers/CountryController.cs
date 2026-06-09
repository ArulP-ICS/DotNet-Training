using Microsoft.AspNetCore.Mvc;
using Problem1.Models;

namespace Problem1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private static List<Country> countries = new List<Country>()
        {
            new Country
            {
                ID = 1,
                CountryName = "India",
                Capital = "New Delhi"
            },
            new Country
            {
                ID = 2,
                CountryName = "USA",
                Capital = "Washington D.C"
            }
        };

        // GET ALL
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            return Ok(countries);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);

            if (country == null)
                return NotFound("Country Not Found");

            return Ok(country);
        }

        // INSERT
        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            countries.Add(country);

            return Ok("Country Added Successfully");
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);

            if (country == null)
                return NotFound("Country Not Found");

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;

            return Ok("Country Updated Successfully");
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);

            if (country == null)
                return NotFound("Country Not Found");

            countries.Remove(country);

            return Ok("Country Deleted Successfully");
        }
    }
}