using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApp.Shared;

namespace WeatherApp.Client.Pages
{
    public class CurrentWeatherBase : ComponentBase
    {
        [Inject]
        public HttpClient Client { get; set; }

        protected RealtimeWeather Current { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            Current = await Client.GetFromJsonAsync<RealtimeWeather>("Current");
        }
    }
}
