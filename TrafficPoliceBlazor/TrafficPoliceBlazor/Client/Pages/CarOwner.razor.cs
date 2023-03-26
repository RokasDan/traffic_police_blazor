using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class CarOwner : ComponentBase
    {
        private people[] people = Array.Empty<people>();
        private long searchLong { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Quering our Navigation link for an officer id.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            searchLong = Convert.ToInt64(queryParams["id"]);

            people = await Http.GetFromJsonAsync<people[]>($"api/people/Single/{searchLong}");

        }

        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }

        //Method which goes to persons details 
        private void PersonDetails(long PersonId)
        {
            NavigationManager.NavigateTo($"/PersonCars?id={PersonId}");
        }
    }
}
