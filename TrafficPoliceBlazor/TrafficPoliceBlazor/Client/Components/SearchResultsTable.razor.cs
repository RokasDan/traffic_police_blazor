using Microsoft.AspNetCore.Components;

namespace TrafficPoliceBlazor.Client.Components
{
    public partial class SearchResultsTable : ComponentBase
    {
        [Parameter]
        public object tableContent { get; set; }
    }
}
