﻿using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using TrafficPoliceBlazor.Shared;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace TrafficPoliceBlazor.Client.Pages
{
    public partial class AddVehicle : ComponentBase
    {
        private LoginModel add = new LoginModel();
        private cars newCars = new cars();
        private people[] peoples = Array.Empty<people>();
        private string? testy { get; set; }

        public class LoginModel
        {
            [RegularExpression(@"^\S+$", ErrorMessage = "Number plate can contain only white space characters.")]
            [Required(ErrorMessage = "Number plate can't be empty!")]
            public string? numberPlate { get; set; }

            [Required(ErrorMessage = "Brand can't be empty!")]
            public string? brand { get; set; }

            [Required(ErrorMessage = "Model can't be empty!")]
            public string? model { get; set; }

            [Required(ErrorMessage = "Colour can't be empty!")]
            public string? colour { get; set; }

            [Range(1, long.MaxValue, ErrorMessage = "Please select a person.")]
            public long owner { get; set; }
        }

        // Getting all of the people options for the car owner choice.
        protected override async Task OnInitializedAsync()
        {
            peoples = await Http.GetFromJsonAsync<people[]>("/api/people");
        }

        // Go back button method.
        private void Goback()
        {
            NavigationManager.NavigateTo("javascript:history.back()");
        }

        // Add vehicle method.
        private async Task AddingVehicle()
        {
            // Checking if a car user wants to add already exists.
            var plateCheck = await Http.GetAsync($"api/cars/GetCarDirect/{add.numberPlate}");
            if (plateCheck.IsSuccessStatusCode)
            {
                testy = "Car with this plate number already exists!";
                return;
            }
  

            // Create the car object for adding a new car.
            newCars.number_plate = add.numberPlate;
            newCars.brand = add.brand;
            newCars.model = add.model;
            newCars.colour = add.colour;
            newCars.owner = add.owner;

            // Calling the Post method
            var test = await Http.PostAsJsonAsync<cars>("/api/cars", newCars);
            if (test.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("javascript:history.back()");
            }
            else
            {
                testy = "Connection to the database is lost!";
            }
        }
    }
}
