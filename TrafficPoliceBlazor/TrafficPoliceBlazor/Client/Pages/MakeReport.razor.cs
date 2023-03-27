using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace TrafficPoliceBlazor.Client.Pages
{
    public  partial class MakeReport : ComponentBase
    {


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

        }

        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }

        private async Task AddReport()
        {
            return;
        }

    }
}
