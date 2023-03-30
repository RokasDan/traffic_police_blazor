using Microsoft.AspNetCore.Components;
using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using TrafficPoliceBlazor.Shared;


namespace TrafficPoliceBlazor.Client.Components
{
    public partial class SearchResultsTableLink : ComponentBase
    {
        [Parameter]
        public object tableContent { get; set; }

        [Parameter]
        public string[] columnsToDisplay { get; set; }

        [Parameter]
        public string LinkPrefix { get; set; }

        [Parameter]
        public string SearchColumn { get; set; }


        public void HandleButtonClick(object row)
        {
            
            var searchValue = row.GetType().GetProperty(SearchColumn)?.GetValue(row);
            Console.WriteLine(SearchColumn);
            Console.WriteLine(searchValue);
            if (searchValue != null)
            {
                
                //GoToLink(LinkPrefix, searchValue);
            }
        }

        public void GoToLink(string prefix, string searchQuery)
        {
            string search = searchQuery.ToString();

            Navigation.NavigateTo($"{prefix}{search}");
        }
    }
}
