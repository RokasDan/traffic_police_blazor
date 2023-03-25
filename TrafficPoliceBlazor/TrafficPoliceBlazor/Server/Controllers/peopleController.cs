using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
