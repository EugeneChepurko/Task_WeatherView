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
        public static async Task<string> GetWeatherForFiveDays(string city/*, string code*/)
        {
            var http1 = new HttpClient();
            var response1 = await http1.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=b3c828810d3a5a76bc521cf9479b61a4&units=metric");
            var result1 = await response1.Content.ReadAsStringAsync();

            var serializer1 = new DataContractJsonSerializer(typeof(GetCurrentCity));
            var memory_stream1 = new MemoryStream(Encoding.UTF8.GetBytes(result1));
            var data1 = (GetCurrentCity)serializer1.ReadObject(memory_stream1);

            //-------------------------------------------------------
            var code = data1.sys.country;
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
        public async Task<IActionResult> Click(string city/*, string code*/)
        {
            string weather = await GetWeatherForFiveDays(city/*, code*/);
            return Ok(weather.ToString());
        }
    }
}