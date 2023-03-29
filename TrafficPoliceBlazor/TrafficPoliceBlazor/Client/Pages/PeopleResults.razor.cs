using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class PeopleResults : ComponentBase
    {

        private people[] people = Array.Empty<people>();
        private string? searchString { get; set; }


        // Getting our previusly info from the querry we used for search.
        protected override async Task OnInitializedAsync()
        {
            // Quering our Navigation link for an officer id.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            searchString = queryParams["Search"];

            people = await Http.GetFromJsonAsync<people[]>($"api/people/Check/{searchString}");
        }

        //Method which goes to persons details 
        private void PersonDetails(long PersonId)
        {
            NavigationManager.NavigateTo($"/PersonCars?id={PersonId}");
        }

        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
