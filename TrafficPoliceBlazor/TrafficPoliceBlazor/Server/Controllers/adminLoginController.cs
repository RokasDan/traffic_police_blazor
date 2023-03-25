using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrafficPoliceBlazor.Server.Dal;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class adminLoginController : ControllerBase
    {
        private readonly ILogger<adminLoginController> _logger;
        private readonly adminDbContext _ctx;

        public adminLoginController(ILogger<adminLoginController> logger, adminDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        [Route("{Username}")]
        public async Task<IActionResult> GetPassword(string Username)
        {
            var password = await _ctx.admins.Where(p => p.Username == Username).FirstOrDefaultAsync();
            if (password != null)
            {
                return Ok(password);
            }
            else
            {
                return BadRequest("No password found for the given username.");
            }
        }
    }
}
