﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Xtramile.Library
{
    public class WeatherService
    {
        private readonly HttpClient _client;

        public WeatherService(HttpClient client)
        {
            if(client.BaseAddress == null)
                client.BaseAddress = new Uri("https://api.openweathermap.org");
            _client = client;
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string countryCode, string city)
        {
            var response = new WeatherResponse();

            try
            {
                var jsonString = await _client.GetStringAsync($"data/2.5/weather?q={city.ToLowerInvariant()},{countryCode.ToLowerInvariant()}&appid=48a07679a19acd346f11af2f79da87a8");

                var weather = JsonSerializer.Deserialize<WeatherVM>(jsonString);

                response.Status = true;
                response.Entity = weather;
            }
            catch(Exception ex) 
            {
                response.Status = false;
                response.Message = ex.Message;
            } 
            

            return response;
        }
    }

}
