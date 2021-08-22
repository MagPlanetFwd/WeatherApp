using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherApp.Shared;

namespace WeatherApp.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CurrentController : ControllerBase
    {
        private readonly HttpClient _client;

        public CurrentController(HttpClient httpClient)
        {
            _client = httpClient;
        }

        [HttpGet]
        public async Task<CurrentWeather> Get()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=seattle"),
                Headers = {
                    { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
                    { "x-rapidapi-key", "3b1420514dmshcc60c7230ee1acep1ac28djsn24c18be253c2" },
                },
            };
            using var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var weather = await response.Content.ReadFromJsonAsync<CurrentWeather>();
            return weather;
        }
    }
}
