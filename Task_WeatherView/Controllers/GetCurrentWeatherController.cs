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

namespace Task_WeatherView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCurrentWeatherController : ControllerBase
    {
        public static async Task<string> GetWeather(string city)
        {

            var http = new HttpClient();
            var response = await http.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=b3c828810d3a5a76bc521cf9479b61a4&units=metric");
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(GetCurrentCity));
            var memory_stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (GetCurrentCity)serializer.ReadObject(memory_stream);
            return data.ToString();
        }
        /// <summary>
        /// Get weather in spicific city
        /// </summary>
        /// <param name="city"></param>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        ///  
        ///     GET /Todo
        ///     {
        ///        "key": "0e7ad584-7788-4ab1-95a6-ca0a5b444cbb",
        ///        "name": "city"  
        ///     }
        /// 
        /// </remarks>
        /// <returns>Get current weather</returns>
        [HttpGet]
        public async Task<IActionResult> Get(string city)
        {
            var weather = await GetWeather(city);
            return Ok(weather.ToString());
        }
        //public override string ToString()
        //{
        //    ResponseWeather weather = new ResponseWeather();
        //    return $"Current temp: {weather.main.temp} °C/n{weather.main.humidity}";
        //}
    }
}