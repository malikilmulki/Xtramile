using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xtramile.Library;
using XtramileSolution.Models;

namespace XtramileSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private WeatherService _weatherService;
        public class SearchParameter
        {
            public string CountryCode { get; set; }
            public string City { get; set; }
        }
        public HomeController(ILogger<HomeController> logger, WeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCountry()
        {
            string? search = Request.Form["term"].FirstOrDefault();

            var countries = GetCountries();
            var data = countries.Select(x => new SelectListItem() { Value = Convert.ToString(x.CountryCode), Text = x.CountryName }).ToList();
            if(!string.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.Text.ToLowerInvariant().Contains(search)).ToList();
            }
            return new JsonResult(data);
        }

        private List<CountryVM> GetCountries()
        {
            using (StreamReader r = new StreamReader("world.json"))
            {
                string jsonString = r.ReadToEnd();
                return JsonSerializer.Deserialize<List<CountryVM>>(jsonString);
            }
        }

        private List<CityVM> GetCities()
        {
            try
            {
                using (StreamReader r = new StreamReader("city.list.json"))
                {
                    string jsonString = r.ReadToEnd();
                    return JsonSerializer.Deserialize<List<CityVM>>(jsonString);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCity()
        {
            string countryCode = Request.Form["countryCode"].FirstOrDefault();
            string? search = Request.Form["term"].FirstOrDefault();

            var cities = GetCities();
            var data = cities.Where(m => m.CountryCode == countryCode);
            
            var result = data.Select(x => new SelectListItem() { Value = Convert.ToString(x.Name), Text = x.Name }).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.Text.ToLowerInvariant().Contains(search)).ToList();
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(SearchParameter searchParameter)
        {
            string? countryCode = Request.Form["CountryCode"].FirstOrDefault();
            string? city = Request.Form["City"].FirstOrDefault();

            var tempData = await _weatherService.GetWeatherAsync(countryCode, city);
            
            return new OkObjectResult(tempData);
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
