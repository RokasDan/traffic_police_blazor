using Microsoft.AspNetCore.Components;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class Menu : ComponentBase
    {
        private string? officerId { get; set; }
        private string? officerName { get; set; }




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

        // Go to vehicle search
        private void VehicleSearch()
        {
            NavigationManager.NavigateTo("/CarSearch");
        }

        // Go to report search
        private void ReportSearch()
        {
            NavigationManager.NavigateTo("/ReportSearch");
        }

        // Go to make report
        private void MakeReport()
        {
            NavigationManager.NavigateTo($"/MakeReport?id={officerId}");
        }

        // Go to Add person.
        private void AddPerson()
        {
            NavigationManager.NavigateTo($"/AddPerson");
        }

        // Go to add vehicle
        private void AddVehicle()
        {
            NavigationManager.NavigateTo($"/AddVehicle");
        }

        // Go to change password
        private void changePassword()
        {
            NavigationManager.NavigateTo($"/ChangePassword?id={officerId}");
        }

        // Log out.
        private void Logout()
        {
            localStorage.RemoveItemAsync("username");
            NavigationManager.NavigateTo("/");
        }
    }
}
