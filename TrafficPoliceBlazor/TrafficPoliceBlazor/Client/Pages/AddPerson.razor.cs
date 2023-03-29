using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using TrafficPoliceBlazor.Shared;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace TrafficPoliceBlazor.Client.Pages
{    public partial class AddPerson :ComponentBase
    {
        private LoginModel add = new LoginModel();
        private people newPerson = new people();
        private string? testy { get; set; }

        public class LoginModel
        {
            [RegularExpression(@"^\S+$", ErrorMessage = "Name can contain only white space characters.")]
            [Required(ErrorMessage = "Name can't be empty!")]
            public string? firstName { get; set; }

            [RegularExpression(@"^\S+$", ErrorMessage = "Surname can contain only white space characters.")]
            [Required(ErrorMessage = "Surname can't be empty!")]
            public string? lastName { get; set; }

            [Required(ErrorMessage = "Address can't be empty!")]
            public string? address { get; set; }

            [Required(ErrorMessage = "Date Of Birth can't be empty!")]
            public DateTime date_of_birth { get; set; }

            [RegularExpression(@"^\S+$", ErrorMessage = "License Number can contain only white space characters.")]
            [Required(ErrorMessage = "License Number can't be empty!")]
            public string? licenseNumber { get; set; }
        }

        // Create back method for back button.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }


        // Adding person to data base.
        private async Task AddingPerson()
        {
            // Creating the new person object
            newPerson.first_name = add.firstName;
            newPerson.last_name = add.lastName;
            newPerson.address = add.address;
            newPerson.date_of_birth = add.date_of_birth;
            newPerson.license_number = add.licenseNumber;

            // Calling the Post method
            var test = await Http.PostAsJsonAsync<people>("/api/people", newPerson);

            // If succeded go back to main page
            if (test.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("javascript:history.back()");
            }
            else
            {
                testy = "Connection to the database is lost!";
            }
        }
    }
}
