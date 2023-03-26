using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using TrafficPoliceBlazor.Shared;
using static TrafficPoliceBlazor.Client.Pages.Login;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class PersonCars : ComponentBase
    {
        private long searchLong { get; set; }
        private cars[] cars { get; set; } = Array.Empty<cars>();
        private string error { get; set; }

        protected override async Task OnInitializedAsync()
        {
            // Quering our Navigation for a long seach string.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            searchLong = Convert.ToInt64(queryParams["id"]);

            var result = await Http.GetAsync($"api/cars/PersonCars/{searchLong}");

            if (result.IsSuccessStatusCode)
            {
                cars = await result.Content.ReadFromJsonAsync<cars[]>();
            }
            else
            {
                error = "Person Has No Cars!";
            }

        }

        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
