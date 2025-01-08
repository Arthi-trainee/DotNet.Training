using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_Assesment.Models;

namespace API_Assesment.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { ID = 1, CountryName = "Country1", Capital = "capital1" },
            new Country { ID = 2, CountryName = "Contry2", Capital = "capital2" }
        };

        // GET: api/Country
        [HttpGet]
        public IHttpActionResult GetAllCountries()
        {
            return Ok(countries);
        }

        // GET: api/Country/1
        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        // POST: api/Country
        [HttpPost]
        public IHttpActionResult AddCountry(Country country)
        {
            if (country == null)
                return BadRequest("Invalid data.");

            countries.Add(country);
            return Created($"api/Country/{country.ID}", country);
        }

        // PUT: api/Country/1
        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Country updatedCountry)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            country.CountryName = updatedCountry.CountryName;
            country.Capital = updatedCountry.Capital;
            return Ok(country);
        }

        // DELETE: api/Country/1
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
                return NotFound();

            countries.Remove(country);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
