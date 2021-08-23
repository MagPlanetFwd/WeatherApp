using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class CurrentSecureController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public CurrentSecureController(HttpClient httpClient, IConfiguration configuration)
        {
            _client = httpClient;
            _config = configuration;
        }

        [HttpGet]
        public async Task<RealtimeWeather> Get()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=seattle"),
                Headers = {
                    { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
                    { "x-rapidapi-key", _config["XRapidapiKey"] },
                },
            };
            using var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var weather = await response.Content.ReadFromJsonAsync<RealtimeWeather>();
            return weather;
        }
    }
}
