﻿using System;
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
//using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Task_WeatherView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCurrentWeatherController : ControllerBase
    {
        public static async Task<string> GetWeather(string city)
        {
            if(city == null)
                return StatusCodes.Status400BadRequest.ToString();

            var http = new HttpClient();
            var response = await http.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=b3c828810d3a5a76bc521cf9479b61a4&units=metric");
            if (response.IsSuccessStatusCode == true)
            {
                var result = await response.Content.ReadAsStringAsync();

                var serializer = new DataContractJsonSerializer(typeof(GetCurrentCity));
                var memory_stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
                var data = (GetCurrentCity)serializer.ReadObject(memory_stream);
                return data.ToString();
            }
            return StatusCodes.Status404NotFound.ToString();
        }
        /// <summary>
        /// Get weather for spicific city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Get weather</returns>
        /// <response code="400">If the city is null</response>
        /// <response code="404">Not found city</response>
        /// <response code="500">Server Error!</response>   
        /// <response code="200">Wow It is Ok!</response>   
        [HttpGet]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(typeof(int), 400)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string city)
        {
            if (city != null)
            {
                var weather = await GetWeather(city);
                return NotFound(weather.ToString());
            }
            return BadRequest();
        }
    }
}