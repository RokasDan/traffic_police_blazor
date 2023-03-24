using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using TrafficPoliceBlazor.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TrafficPoliceBlazor.Pages
{

    public partial class Login : ComponentBase
    {
        public string test;

        // Instance of MyDbContext
        [Inject]
        public MyDbContext dbContext { get; set; }

        // Instaciating Model class for Edit form object
        private LoginModel loginModel = new LoginModel();

        // We create a Model class for the Edit form object.
        public class LoginModel
        {
            [Required(ErrorMessage = "Please enter your officer ID")]
            public string officerId { get; set; }

            [Required(ErrorMessage = "Please enter your Password")]
            public string password { get; set; }
        }


        private async Task HandleLogin()
        {

            var officerId = loginModel.officerId;
            var password = loginModel.password;


            if (dbContext != null)
            {
                var admin = await dbContext.admins.FirstOrDefaultAsync(a => a.Username == officerId && a.Password == password);

                if (admin != null)
                {
                    // Successful login
                    test = "True";
                }
                else
                {
                    // Failed login
                    test = "False";
                }
            }
            else
            {
                Console.WriteLine("Error: dbContext is null.");
            }

        }

    }
}
