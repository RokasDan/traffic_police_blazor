using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;


namespace TrafficPoliceBlazor.Pages
{

    public partial class Login : ComponentBase
    {
        public string test;


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


        }

    }
}
