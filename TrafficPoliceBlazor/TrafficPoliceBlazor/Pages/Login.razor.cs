using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;



namespace TrafficPoliceBlazor.Pages
{
    public partial class Login : ComponentBase
    {

        // Instaciating Model class for Edit form object
        private LoginModel loginModel = new LoginModel();

        private void HandleLogin()
        {
          
        }

        // We create a Model class for the Edit form object.
        public class LoginModel
        {
            [Required(ErrorMessage = "Please enter your officer ID")]
            public string officerId { get; set; }

            [Required(ErrorMessage = "Please enter your Password")]
            public string password { get; set; }
        }

    }
}
