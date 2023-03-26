using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class ReportResults : ComponentBase
    {
        private string searchString { get; set; }
        private reports[] reports { get; set; } = Array.Empty<reports>();

        protected override async Task OnInitializedAsync()
        {
            // Quering our Navigation link for a report search string.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            searchString = queryParams["Search"];

            var result = await Http.GetAsync($"api/reports/GetReport/{searchString}");

            reports = await result.Content.ReadFromJsonAsync<reports[]>();
           
        }

        //Method which goes to goes to report details page. 
        private void ReportDetails(long reportId)
        {
            NavigationManager.NavigateTo($"/ReportDetails?Search={reportId}");
        }

        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
