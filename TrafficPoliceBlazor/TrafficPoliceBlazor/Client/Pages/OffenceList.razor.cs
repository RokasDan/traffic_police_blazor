using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using TrafficPoliceBlazor.Shared;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class OffenceList : ComponentBase
    {
        // array for offences.
        private offence[] offences = Array.Empty<offence>();

        protected override async Task OnInitializedAsync()
        {
            // Getting info from from offence table with the API.
            offences = await Http.GetFromJsonAsync<offence[]>("/api/offence");
        }
        
        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
