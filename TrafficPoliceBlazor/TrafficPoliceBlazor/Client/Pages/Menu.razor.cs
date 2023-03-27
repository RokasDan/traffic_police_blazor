using Microsoft.AspNetCore.Components;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class Menu : ComponentBase
    {
        private string officerId { get; set; }
        private string officerName { get; set; }




        // When the page loads we get the ID of the officer who is logged on.
        protected override void OnInitialized()
        {
            // Quering our Navigation link for an officer id.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            officerId = queryParams["id"];

            if (officerId != null)
            {
                officerName = officerId;
            }
        }

        // Go to people search
        private void PeopleSearch()
        {
            NavigationManager.NavigateTo("/PeopleSearch");
        }

        // Go to list of offences
        private void OffenceList()
        {
            NavigationManager.NavigateTo("/offenceList");
        }

        private void VehicleSearch()
        {
            NavigationManager.NavigateTo("/CarSearch");
        }

        private void ReportSearch()
        {
            NavigationManager.NavigateTo("/ReportSearch");
        }

        private void MakeReport()
        {
            NavigationManager.NavigateTo($"/MakeReport?id={officerId}");
        }

        private void AddPerson()
        {
            NavigationManager.NavigateTo($"/AddPerson");
        }

        private void AddVehicle()
        {
            NavigationManager.NavigateTo($"/AddVehicle");
        }
    }
}
