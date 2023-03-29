using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;
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

        // Method to get all car enteries
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _ctx.cars
                            .Select(c => new {
                                number_plate = c.number_plate,
                                Brand = c.brand,
                                Model = c.model ?? "Uknown Model",
                                Colour = c.colour,
                                Owner = c.owner
                            })
                            .ToListAsync();
            return Ok(cars);
        }

        //Get cars for a specific person
        [HttpGet("PersonCars/{Searchlong}")]
        public async Task<IActionResult> PersonCars(long SearchLong)
        {
            // Looking for cars with a specific owner 
            var cars = await _ctx.cars
                                    .Where(c => c.owner == SearchLong)
                                    .Select(c => new
                                    {
                                        number_plate = c.number_plate ?? "N/A",
                                        brand = c.brand ?? "N/A",
                                        model = c.model ?? "N/A",
                                        colour = c.colour ?? "N/A",
                                        owner = c.owner
                                    })
                                    .ToListAsync();


            if (cars != null && cars.Any())
            {
                return Ok(cars);
            }
            else
            {
                return BadRequest();
            }
        }

        //Get car with a specific number plate
        [HttpGet("CarSearch/{SearchString}")]
        public async Task<IActionResult> Search(string SearchString)
        {
            // Looking for cars with a number plate which matches our full or partial number plate. 
            var cars = await _ctx.cars
                                    .Where(c => c.number_plate.Contains(SearchString))
                                    .Select(c => new {
                                        number_plate = c.number_plate ?? "N/A",
                                        brand = c.brand ?? "N/A",
                                        model = c.model ?? "N/A",
                                        colour = c.colour ?? "N/A",
                                        owner = c.owner
                                    })
                                    .ToListAsync();


            if (cars != null && cars.Any())
            {
                return Ok(cars);
            }
            else
            {
                return BadRequest();
            }
        }

        //Get single car with its ID
        [HttpGet("GetCarDirect/{SearchString}")]
        public async Task<IActionResult> GetCarDirect(string SearchString)
        {
            // Looking for cars with a number plate which matches exact numberplate. 
            var car = await _ctx.cars
                                    .Where(c => c.number_plate == SearchString)
                                    .Select(c => new {
                                        number_plate = c.number_plate ?? "N/A",
                                        brand = c.brand ?? "N/A",
                                        model = c.model ?? "N/A",
                                        colour = c.colour ?? "N/A",
                                        owner = c.owner
                                    })
                                    .FirstOrDefaultAsync();

            if (car != null)
            {
                return Ok(car);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] cars newCar)
        {
            _ctx.cars.Add(newCar);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

    }
}
