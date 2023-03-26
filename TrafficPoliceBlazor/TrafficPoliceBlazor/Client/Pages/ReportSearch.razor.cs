using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class ReportSearch : ComponentBase
    {
        private string test { get; set; }

        // Instaciating Model class for Edit form object
        private SearchModel searchModel = new SearchModel();

        // We create a Model class for the Edit form object.
        public class SearchModel
        {
            [Required(ErrorMessage = "Please enter a an exact veichle pate, first name or last name!")]
            public string searchString { get; set; }
        }

        // Handeling seach
        private async Task HandleSeach()
        {
            var search = searchModel.searchString;

            // Looking for person Id if a full name is entered
            var offenderId = await Http.GetAsync($"api/people/GetId/{search}");
            
            // We get that specific persons Id if the Full name seach was  sucesfull
            if (offenderId.IsSuccessStatusCode)
            {
                var content = await offenderId.Content.ReadAsStringAsync();
                var people_id = long.Parse(content);

                var NewSearchString = people_id.ToString();
                await reportSearch(NewSearchString);

            } else
            {
                // If no person id was found in the seach we use what the user entered directly in the search as a car number
                await reportSearch(search);
            }
        }

        // Method to check if we recieve anything at all with our querry.
        private async Task reportSearch(string searchString)
        {

            var response = await Http.GetAsync($"api/reports/GetReport/{searchString}");

            // If so we navigate to page where we will display our querry.
            if (response.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo($"/ReportResults?Search={searchString}");
            }
            else
            {
                // If we get nothing we display this message.
                test = "Search had no results!";
            }

        }


        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
