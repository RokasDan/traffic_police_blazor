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

        //Get all of the offences.
        [HttpGet]
        public async Task<IActionResult> GetOffenses()
        {
            var offenses = await _ctx.offence.ToListAsync();
            return Ok(offenses);
        }

        //Get a specific offence with ID.
        [HttpGet("GetDirectOffence/{SearchId}")]
        public async Task<IActionResult> GetDirectOffenses(long SearchId)
        {
            var offenses = await _ctx.offence.Where(o => o.Offence_ID == SearchId)
                                             .Select(o => new 
                                             {
                                                 Offence_ID = o.Offence_ID,
                                                 description = o.description,
                                                 maxFine = o.maxFine,
                                                 maxPoints = o.maxPoints                                                 
                                             })
                                    .FirstOrDefaultAsync();
            if (offenses != null)
            {
                return Ok(offenses);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
