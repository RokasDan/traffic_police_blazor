using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using TrafficPoliceBlazor.Shared;


namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class Login : ComponentBase
    {

        // Instaciating Model class for Edit form object
        private LoginModel loginModel = new LoginModel();

        // We create a Model class for the Edit form object.
        public class LoginModel
        {
            [Required(ErrorMessage = "Please enter your officer ID")]
            public string? officerId { get; set; }

            [Required(ErrorMessage = "Please enter your Password")]
            public string? password { get; set; }
        }

        // String for error messages
        private string? test;

        // Handeling login.
        private async Task GetLogin()
        {
            test = "Checking Credentials!";
            // Sending the Http get Request
            var response = await Http.GetAsync($"api/adminLogin/{loginModel.officerId}/{loginModel.password}");
            if (response.IsSuccessStatusCode)
            {
                var Id = loginModel.officerId;

                // Setting the user name to local storage
                await localStorage.SetItemAsync<string>("username", Id);

                //Moving to main menu.
                NavigationManager.NavigateTo($"/Menu?id={Id}");

            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                // User doesnt exist
                test = "OfficerID or Password is Wrong!";
            } 
            else
            {
                test = "Connection to database is unsuccessful!";
            }

        }
    }
}
