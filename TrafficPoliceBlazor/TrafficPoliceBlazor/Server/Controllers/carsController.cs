using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrafficPoliceBlazor.Server.Dal;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class carsController : ControllerBase
    {
        private readonly ILogger<carsController> _logger;
        private readonly carsDbContext _ctx;

        public carsController(ILogger<carsController> logger, carsDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        // CRUD methods here !

        //Get cars for a specific person
        [HttpGet("PersonCars/{Searchlong}")]
        public async Task<IActionResult> PersonCars(long SearchLong)
        {
            // Looking for cars with a specific owner 
            var cars = await _ctx.cars.Where(c => c.owner == SearchLong).ToListAsync();


            if (cars != null && cars.Any())
            {
                return Ok(cars);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
