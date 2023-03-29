using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class CarResults : ComponentBase
    {
        private string error { get; set; }
        private string searchString { get; set; }
        private cars[] cars { get; set; } = Array.Empty<cars>();

        // Getting our previusly info from the querry we used for search.
        protected override async Task OnInitializedAsync()
        {
            // Quering our Navigation link for a car number plate.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            searchString = queryParams["Search"];

            var result = await Http.GetAsync($"api/cars/CarSearch/{searchString}");

            if (result.IsSuccessStatusCode)
            {
                cars = await result.Content.ReadFromJsonAsync<cars[]>();
            }
            else
            {
                error = "No Cars Found!";
            }
        }

        //Method which goes to details of the car owner. 
        private void OwnerDetails(long ownerId)
        {
            NavigationManager.NavigateTo($"/CarOwner?id={ownerId}");
        }

        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
