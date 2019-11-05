using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task_WeatherView.Models;

namespace Task_WeatherView.Controllers
{
    //[Produces("application/json")]
    //[Route("api/[controller]")]
    //[ApiController]
    public class HomeController : Controller
    {
        //public static async Task<RootObject> GetWeather(string city)
        //{
        //    var http = new HttpClient();
        //    var response = await http.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=b3c828810d3a5a76bc521cf9479b61a4&units=metric");
        //    var result = await response.Content.ReadAsStringAsync();

        //    var serializer = new DataContractJsonSerializer(typeof(RootObject));
        //    var memory_stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
        //    var data = (RootObject)serializer.ReadObject(memory_stream);
        //    return data;
        //}

        //[HttpGet]
        //[Route("api/[controller]")]
        //public async Task<IActionResult> Get(string city)
        //{
        //    RootObject weather = await GetWeather(city);
        //    return Ok(weather);
        //}
        // -------------------------------------------------------------------------------
        //public static async Task<RootObject> GetWeatherForFiveDays(string city)
        //{
        //    var http = new HttpClient();
        //    var response = await http.GetAsync($"http://api.openweathermap.org/data/2.5/forecast?q={city},us&appid=b6907d289e10d714a6e88b30761fae22&units=metric");
        //    var result = await response.Content.ReadAsStringAsync();

        //    var serializer = new DataContractJsonSerializer(typeof(RootObject));
        //    var memory_stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
        //    var data = (RootObject)serializer.ReadObject(memory_stream);
        //    return data;
        //}

        //[HttpGet]
        //[Route("api/[controller]")]
        //public async Task<IActionResult> Click(string city)
        //{
        //    RootObject weather = await GetWeatherForFiveDays(city);
        //    return Ok(weather);
        //}








        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
