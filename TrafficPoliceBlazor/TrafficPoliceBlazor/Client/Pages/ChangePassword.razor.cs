using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http.Json;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class ChangePassword : ComponentBase
    {
        // We create a Model class for the Edit form object.
        private LoginModel newPass = new LoginModel();
        private admins passwordString = new admins();
        private string test { get; set; }

        public class LoginModel
        {
            [Required(ErrorMessage = "This field can't be empty!")]
            public string CurrentPassword { get; set; }

            [Required(ErrorMessage = "This field can't be empty!")]
            public string NewPassword { get; set; }

            [Required(ErrorMessage = "This field can't be empty!")]
            public string ConfirmPassword { get; set; }
        }

        private async Task changePassword()
        {
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var officer = queryParams["id"];

            var response = await Http.GetAsync($"api/adminLogin/{officer}/{newPass.CurrentPassword}");
            if (response.IsSuccessStatusCode)
            {
                if(newPass.NewPassword == newPass.ConfirmPassword)
                {
                    passwordString.Username = officer;
                    passwordString.Password = newPass.NewPassword;

                    var update = await Http.PutAsJsonAsync($"api/adminLogin/{officer}", passwordString);
                    if (update.IsSuccessStatusCode)
                    {
                        // Report updated successfully
                        NavigationManager.NavigateTo("/Login");
                    }
                    else
                    {
                        // Error updating report
                        test = "Could Not Submit your change!";
                    }
                }
                else
                {
                    test = "Your new passwords didn't match!";
                }
            }
            else
            {
                test = "Your password is incorrect!";
            }

        }

        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
