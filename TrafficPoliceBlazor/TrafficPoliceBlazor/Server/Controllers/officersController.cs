using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrafficPoliceBlazor.Server.Dal;
using TrafficPoliceBlazor.Shared;


namespace TrafficPoliceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class officersController : ControllerBase
    {
        private readonly ILogger<officersController> _logger;
        private readonly officersDbContext _ctx;

        public officersController(ILogger<officersController> logger, officersDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        // CRUD methods here!
    }
}
