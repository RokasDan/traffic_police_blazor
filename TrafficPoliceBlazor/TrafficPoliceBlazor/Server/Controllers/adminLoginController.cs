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
        [Route("{Username}/{Password}")]
        public async Task<IActionResult> GetPassword(string Username, string Password)
        {
            // Querying the data base.
            var password = await _ctx.admins.Where(p => p.Username == Username).FirstOrDefaultAsync();
            if (password != null)
            {
                // Checking if our password is the same the user entered.
                if(password.Password == Password)
                {
                    // If so we send success message
                    return Ok();
                }
                else
                {
                    // Else we give error
                    return BadRequest("Wrong Password");
                }
            }
            else
            {
                // We also give error
                return BadRequest("No password found for the given username.");
            }
        }
    }
}
