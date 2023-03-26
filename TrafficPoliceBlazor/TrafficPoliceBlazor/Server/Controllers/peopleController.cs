﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
