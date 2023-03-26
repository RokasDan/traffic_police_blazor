using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using TrafficPoliceBlazor.Shared;
using Newtonsoft.Json;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class ReportDetails : ComponentBase
    {
        //Offence detail entities
        private dynamic offenceSearch { get; set; }
        private long Offence_ID { get; set; }
        private string description { get; set; }
        private string maxFine { get; set; }
        private string maxPoints { get; set; }

        //People invloved in the report entities
        private dynamic peopleSearch { get; set; }
        private long offenderId { get; set; }
        private string first_name { get; set; }
        private string last_name { get; set; }
        private string address { get; set; }
        private DateTime date_of_birth { get; set; }
        private string license_number { get; set; }


        //Car invloved in the report entities
        public string carTest { get; set; }
        private dynamic vehicleSearch { get; set; }
        private string number_plate { get; set; }
        private string brand { get; set; }
        private string Model { get; set; }
        private string colour { get; set; }
        private long owner { get;  set; }

        //General report entities
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


        protected override async Task OnInitializedAsync()
        {
            // Quering our Navigation link for a report search string.
            var uri = new Uri(NavigationManager.Uri);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            searchId = queryParams["Search"];


            // Getting initial report details.
            var result = await Http.GetAsync($"api/reports/GetDirectReport/{searchId}");
      
            var content = await result.Content.ReadAsStringAsync();

            // Setting general repot entities
            report = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

            report_id = report.report_id;
            author = report.author;
            car_id = report.car_id;
            people_id = report.people_id;
            offence_id = report.offence_id; 
            fine_issued = report.fine_issued;
            points_issued = report.points_issued;
            details = report.details;

            // Getting car involved in report.
            if(car_id == "No Car Involved")
            {
                carTest = car_id;
            }
            else
            {
                // Getting initial report details.
                var reportCar = await Http.GetAsync($"api/cars/GetCarDirect/{car_id}");
                var contentCar = await reportCar.Content.ReadAsStringAsync();

                vehicleSearch = Newtonsoft.Json.JsonConvert.DeserializeObject(contentCar);

                number_plate = vehicleSearch.number_plate;
                brand = vehicleSearch.brand;
                Model = vehicleSearch.model;
                colour = vehicleSearch.colour;
                owner = vehicleSearch.owner;
            }

            // Getting the involved Person.
            var reportPerson = await Http.GetAsync($"api/people/GetPersonReport/{people_id}");
            var conntentPerson = await reportPerson.Content.ReadAsStringAsync();

            peopleSearch = Newtonsoft.Json.JsonConvert.DeserializeObject(conntentPerson);

            offenderId = peopleSearch.people_id;
            first_name = peopleSearch.first_name;
            last_name = peopleSearch.last_name;
            address = peopleSearch.address;
            date_of_birth = peopleSearch.date_of_birth;
            license_number = peopleSearch.license_number;

            // Getting the information of the offence.
            var reportOffence = await Http.GetAsync($"api/offence/GetDirectOffence/{offence_id}");
            var conntentOffence = await reportOffence.Content.ReadAsStringAsync();

            offenceSearch = Newtonsoft.Json.JsonConvert.DeserializeObject(conntentOffence);

            Offence_ID = report.offence_id;
            description = offenceSearch.description;
            maxFine = offenceSearch.maxFine;
            maxPoints = offenceSearch.maxPoints;

            carTest = colour;

        }

        //Method which goes to persons details 
        private void EditReport()
        {
            NavigationManager.NavigateTo($"/EditReport?Person={offenderId}&Report={report_id}&Car={car_id}&Offence={offence_id}");
        }

        // Go back one page method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }
    }
}
