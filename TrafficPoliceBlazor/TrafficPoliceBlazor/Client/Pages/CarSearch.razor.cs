using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class CarSearch : ComponentBase
    {
        private string test { get; set; }

        // Instaciating Model class for Edit form object
        private SearchModel searchModel = new SearchModel();

        // We create a Model class for the Edit form object.
        public class SearchModel
        {
            [Required(ErrorMessage = "Please enter a a full or partial Vehicle Plate")]
            public string searchString { get; set; }
        }

        // Handeling seach
        private async Task HandleSeach()
        {
            var search = searchModel.searchString;

            await carSearch(search);
        }

        // Method to check if we recieve anything at all with our querry.
        private async Task carSearch(string searchString)
        {

            var response = await Http.GetAsync($"api/cars/CarSearch/{searchString}");

            // If so we navigate to page where we will display our querry.
            if (response.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo($"/CarResults?Search={searchString}");
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
