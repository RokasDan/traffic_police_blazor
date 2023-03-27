using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TrafficPoliceBlazor.Server.Dal;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class peopleController : ControllerBase
    {
        private readonly ILogger<peopleController> _logger;
        private readonly peopleDbContext _ctx;

        public peopleController(ILogger<peopleController> logger, peopleDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        // CRUD methods here!
        //Method to get all people in the database
        [HttpGet]
        public async Task<IActionResult> GetOffenses()
        {
            var people = await _ctx.people.Select(p => new {
                                        people_id = p.people_id,
                                        first_name = p.first_name,
                                        last_name = p.last_name,
                                        address = p.address,
                                        date_of_birth = p.date_of_birth,
                                        license_number= p.license_number ?? "No Lisence"
            }).ToListAsync();

            return Ok(people);
        }

        // Method to check if the an entered string returns data.
        [HttpGet("Check/{SearchString}")]
        public async Task<IActionResult> Check(string SearchString)
        {
            // Querying the people table, changing null values to N/A strings
            var searchData = await _ctx.people
                                        .Where(p => p.license_number.Contains(SearchString)
                                    || p.first_name.Contains(SearchString)
                                    || p.last_name.Contains(SearchString))
                                        .Select(p => new {
                                        people_id = p.people_id,
                                        first_name = p.first_name ?? "N/A",
                                        last_name = p.last_name ?? "N/A",
                                        address = p.address ?? "N/A",
                                        date_of_birth = p.date_of_birth,
                                        license_number = p.license_number ?? "N/A"
                                        })
                                        .Distinct()
                                        .ToListAsync();

            if (searchData != null && searchData.Any())
            {
                return Ok(searchData);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("Single/{SearchLong}")]
        public async Task<IActionResult> Single(long SearchLong)
        {
            // Querying the people table, changing null values to N/A strings
            var searchData = await _ctx.people
                                        .Where(p => p.people_id == (SearchLong))
                                        .Select(p => new {
                                            people_id = p.people_id,
                                            first_name = p.first_name ?? "N/A",
                                            last_name = p.last_name ?? "N/A",
                                            address = p.address ?? "N/A",
                                            date_of_birth = p.date_of_birth,
                                            license_number = p.license_number ?? "N/A"
                                        })
                                        .Distinct()
                                        .ToListAsync();

            if (searchData != null && searchData.Any())
            {
                return Ok(searchData);
            }
            else
            {
                return BadRequest();
            }
        }

        // Method to get a persons Id by entering full name!
        [HttpGet("GetId/{SearchString}")]
        public async Task<IActionResult> GetId(string SearchString)
        {
            string[] words = SearchString.Split(' ');

            if (words.Length != 2)
            {
                return BadRequest("Search string must contain exactly two words.");
            }
            string word1 = words[0];
            string word2 = words[1];

            var searchData = await _ctx.people
                                    .Where(p => p.first_name == word1 && p.last_name == word2)
                                    .Select(p => new {
                                        people_id = p.people_id,
                                        first_name = p.first_name ?? "N/A",
                                        last_name = p.last_name ?? "N/A",
                                        address = p.address ?? "N/A",
                                        date_of_birth = p.date_of_birth,
                                        license_number = p.license_number ?? "N/A"
                                    })
                                    .FirstOrDefaultAsync();

            if (searchData != null)
            {
                return Ok(searchData.people_id);
            }
            else
            {
                return BadRequest();
            }
        }


        // Method to get specific person details with their ID!
        [HttpGet("GetPersonReport/{SearchString}")]
        public async Task<IActionResult> GetPersonReport(long SearchString)
        {
 
            var searchData = await _ctx.people
                                    .Where(p => p.people_id == SearchString)
                                    .Select(p => new {
                                        people_id = p.people_id,
                                        first_name = p.first_name ?? "N/A",
                                        last_name = p.last_name ?? "N/A",
                                        address = p.address ?? "N/A",
                                        date_of_birth = p.date_of_birth,
                                        license_number = p.license_number ?? "N/A"
                                    })
                                    .FirstOrDefaultAsync();

            if (searchData != null)
            {
                return Ok(searchData);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
