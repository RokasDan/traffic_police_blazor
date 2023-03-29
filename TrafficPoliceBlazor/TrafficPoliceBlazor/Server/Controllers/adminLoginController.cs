using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrafficPoliceBlazor.Server.Dal;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Server.Controllers
{
    // Controller for handeling anything assosiated with admin table
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

        // Method which checks if the user has entered a correct user name and if his password mached!
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

        // Method for updating user password!
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePassword(string id, admins newPassword)
        {
            var Update = _ctx.admins.FirstOrDefault(a => a.Username == id);

            if (Update != null)
            {
                Update.Password = newPassword.Password;
                // Update other properties as needed

                _ctx.admins.Update(Update);
                await _ctx.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
