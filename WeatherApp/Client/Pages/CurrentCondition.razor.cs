using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApp.Shared;

namespace WeatherApp.Client.Pages
{
    public class CurrentConditionBase : ComponentBase
    {
        [Inject]
        public HttpClient Client { get; set; }

        protected CurrentWeather Current { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Current = await Client.GetFromJsonAsync<CurrentWeather>("Current");
        }
    }
}
