using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_WeatherView.Models;
using Task_WeatherView.Models.WeatherForecast;

namespace Task_WeatherView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetForecastController : ControllerBase
    {
        public static async Task<string> GetWeatherForFiveDays(string city)
        {
            var code = GetCodeCountry(city);
            var http = new HttpClient();
            var response = await http.GetAsync($"http://api.openweathermap.org/data/2.5/forecast?q={city},{code}&appid=b3c828810d3a5a76bc521cf9479b61a4&units=metric");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(GetForecastCity));
            var memory_stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (GetForecastCity)serializer.ReadObject(memory_stream);
            return data.ToString();
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> Click(string city)
        {
            string weather = await GetWeatherForFiveDays(city);
            return Ok(weather.ToString());
        }

        private static async Task<string> GetCodeCountry(string city)
        {
            var http = new HttpClient();
            var response = await http.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=b3c828810d3a5a76bc521cf9479b61a4&units=metric");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(GetCurrentCity));
            var memory_stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (GetCurrentCity)serializer.ReadObject(memory_stream);

            return data.sys.country;
        }
    }
}