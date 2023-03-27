using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using TrafficPoliceBlazor.Shared;
using static System.Net.Mime.MediaTypeNames;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class EditReport : ComponentBase
    {
        private string TEST { get; set; }

        //Default offence values
        private string offenceSelectorDefault { get; set; }
        private long offenceValueDefault { get; set; }
        private long SelectedOffence { get; set; }

        //Default people values
        private string peopleSelectorDefault { get; set; }
        private long peopleValueDefault { get; set; }
        private long SelectedPeople { get; set; } 

        //Default car values
        private string carSelectorDefault { get; set; }
        private string carValueDefault { get; set; }
        private string SelectedCar { get; set; }

        //General report entities for editing
        private reports updatedReport = new reports();
        private string searchId { get; set; }
        private dynamic report { get; set; }
        private long report_id { get; set; }
        private string author { get; set; }
        private string car_id { get; set; }
        private long people_id { get; set; }
        private long offence_id { get; set; }
        private string fine_issued { get; set; }
        private string points_issued { get; set; }
        private DateTime report_date { get; set; }
        private string details { get; set; }


        // Instaciating Model class for Edit form object
        private LoginModel updateReport = new LoginModel();

        // List for selectors
        private offence[] offences = Array.Empty<offence>();
        private cars[] car = Array.Empty<cars>();
        private people[] peoples = Array.Empty<people>();

        // We create a Model class for the Edit form object.
        public class LoginModel
        {
            public string fineIssued { get; set; }

            public string pointsIssued { get; set; }

            public string details { get; set; }

            public DateTime report_date { get; set; }

        }

        protected override async Task OnInitializedAsync()
        {
            // Quering our Navigation link for a report search string.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            searchId = queryParams["Report"];


            // Getting initial report details.
            var result = await Http.GetAsync($"api/reports/GetDirectReport/{searchId}");

            var content = await result.Content.ReadAsStringAsync();

            // Setting general report entities
            report = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

            report_id = report.report_id;
            author = report.author;
            car_id = report.car_id;
            people_id = report.people_id;
            offence_id = report.offence_id;
            fine_issued = report.fine_issued;
            points_issued = report.points_issued;
            report_date = report.report_date;
            details = report.details;

            if (car_id == "No Car Involved")
            {
                carSelectorDefault = "No Car Involved";
                carValueDefault = "";
     
            }
            else
            {
                // Getting initial car details.
                var reportCar = await Http.GetAsync($"api/cars/GetCarDirect/{car_id}");
                var contentCar = await reportCar.Content.ReadAsStringAsync();
                dynamic vehicleSearch = Newtonsoft.Json.JsonConvert.DeserializeObject(contentCar);

                var number = vehicleSearch.number_plate;
                var brand = vehicleSearch.brand;
                var model = vehicleSearch.model;

                carSelectorDefault = brand + " " + model + " Number Plate - " + number;
                carValueDefault = number;
            }

            // Getting the person details for edit.
            var reportPerson = await Http.GetAsync($"api/people/GetPersonReport/{people_id}");
            var conntentPerson = await reportPerson.Content.ReadAsStringAsync();
            dynamic peopleSearch = Newtonsoft.Json.JsonConvert.DeserializeObject(conntentPerson);

            var personId = peopleSearch.people_id;
            var name = peopleSearch.first_name;
            var surname = peopleSearch.last_name;

            peopleSelectorDefault = "Person ID - " + personId + "   " + name + " " + surname;
            peopleValueDefault = personId;

            // Getting the information of the offence default values.
            var reportOffence = await Http.GetAsync($"api/offence/GetDirectOffence/{offence_id}");
            var conntentOffence = await reportOffence.Content.ReadAsStringAsync();
            dynamic offenceSearch = Newtonsoft.Json.JsonConvert.DeserializeObject(conntentOffence);

            var offenceId = offence_id;
            var description = offenceSearch.description;

            offenceSelectorDefault = "Offence ID - " + offenceId + "   " + description;
            offenceValueDefault = offenceId;
            
            // Presseting the default values
            updateReport.fineIssued = fine_issued;
            updateReport.pointsIssued = points_issued;
            updateReport.details = details;
            updateReport.report_date = report_date;
            SelectedOffence = offenceValueDefault;
            SelectedPeople = peopleValueDefault;
            SelectedCar = carValueDefault;
       

            offences = await Http.GetFromJsonAsync<offence[]>("/api/offence");

            car = await Http.GetFromJsonAsync<cars[]>("/api/cars");

            peoples = await Http.GetFromJsonAsync<people[]>("/api/people");
        }

        private async Task UpdateReport()
        {
            // Creating default values for inputtext fields if they were left null
            if(updateReport.fineIssued == "")
            {
                updateReport.fineIssued = fine_issued;
            }

            if(updateReport.pointsIssued == "")
            {
                updateReport.pointsIssued = points_issued;
            }

            if (updateReport.details == "")
            {
                updateReport.details = details;
            }

            if (updateReport.report_date == DateTime.MinValue)
            {
                updateReport.report_date = report_date;
            }

           
            // Preparing repot object
            updatedReport.report_id = report.report_id;
            updatedReport.author = report.author;
            updatedReport.car_id = SelectedCar;
            updatedReport.people_id = SelectedPeople;
            updatedReport.offence_id = SelectedOffence;
            updatedReport.fine_issued = updateReport.fineIssued;
            updatedReport.points_issued = updateReport.pointsIssued;
            updatedReport.report_date = updateReport.report_date;
            updatedReport.details = updateReport.details;

            var response = await Http.PutAsJsonAsync($"api/reports/{searchId}", updatedReport);
            if (response.IsSuccessStatusCode)
            {
                // Report updated successfully
                NavigationManager.NavigateTo("javascript:history.back()");
            }
            else
            {
                // Error updating report
                TEST = "Could Not Submit your change!";
            }
        }

        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
