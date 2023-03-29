using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrafficPoliceBlazor.Server.Dal;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class unknownController : ControllerBase
    {
        private readonly ILogger<unknownController> _logger;
        private readonly unknownDbContext _ctx;

        public unknownController(ILogger<unknownController> logger, unknownDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        // CRUD methods here!
        // Didnt use the unknown table in the project hence there are no methods!
    }
}
