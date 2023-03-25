using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrafficPoliceBlazor.Server.Dal;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class offenceController : ControllerBase
    {
        private readonly ILogger<offenceController> _logger;
        private readonly offenceDbContext _ctx;

        public offenceController(ILogger<offenceController> logger, offenceDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }
        // CRUD methods here!

        //Get all the rows from the table.
        [HttpGet]
        public async Task<IActionResult> GetOffenses()
        {
            var offenses = await _ctx.offence.ToListAsync();
            return Ok(offenses);
        }
    }
}
