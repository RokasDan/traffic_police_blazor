using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using TrafficPoliceBlazor.Shared;
using static System.Net.Mime.MediaTypeNames;

namespace TrafficPoliceBlazor.Client.Pages
{
    public  partial class MakeReport : ComponentBase
    {
        private string testy { get; set; }

        private offence[] offences = Array.Empty<offence>();
        private cars[] car = Array.Empty<cars>();
        private people[] peoples = Array.Empty<people>();
        private reports newReport = new reports();

        // We create a Model class for the Edit form object.
        private LoginModel makeReport = new LoginModel();
        public class LoginModel
        {
            [Required(ErrorMessage = "Fine cant be empty!")]
            public string fineIssued { get; set; }

            [Required(ErrorMessage = "Points cant be empty!")]
            public string pointsIssued { get; set; }

            [Required(ErrorMessage = "Enter Details of event!")]
            public string details { get; set; }

            [Required(ErrorMessage = "Enter Date of event!")]
            public DateTime report_date { get; set; }

            [Range(1, long.MaxValue, ErrorMessage = "Please select an offence.")]
            public int SelectedOffence { get; set; }

            [Required(ErrorMessage = "Please select a car.")]
            public string SelectedCar { get; set; }

            [Range(1, long.MaxValue, ErrorMessage = "Please select a person.")]
            public int SelectedPeople { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            offences = await Http.GetFromJsonAsync<offence[]>("/api/offence");

            car = await Http.GetFromJsonAsync<cars[]>("/api/cars");

            peoples = await Http.GetFromJsonAsync<people[]>("/api/people");

        }

            private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }

        private async Task AddReport()
        {
            //Preparing new report to be sent
            // Quering our Navigation link for a report search string.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var author = queryParams["id"];

            newReport.author = author;
            newReport.fine_issued = makeReport.fineIssued;
            newReport.points_issued = makeReport.pointsIssued;
            newReport.details = makeReport.details;
            newReport.report_date = makeReport.report_date;
            newReport.offence_id = makeReport.SelectedOffence;
            newReport.car_id = makeReport.SelectedCar;
            newReport.people_id = makeReport.SelectedPeople;

            var test = await Http.PostAsJsonAsync<reports>("/api/reports", newReport);

            if(test.IsSuccessStatusCode)
            {
                testy = "Yeees";
            } else
            {
                testy = "Noooo";
            }
        }

    }
}
