using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Xtramile.Library;

namespace XtramileSolution.Test
{
    internal static class DependencyInjector
    {
        public static IServiceProvider GetServiceProvider()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHttpClient<WeatherService>();

            services.AddSingleton<WeatherService>();
            return services.BuildServiceProvider();
        }
    }

    public class WeatherService_GetWeather
    {
        private WeatherService _weatherService;        

        [OneTimeSetUp]
        public void Prepare()
        {
           
        }

        [SetUp]
        public void Setup()
        {
            IServiceProvider provider = DependencyInjector.GetServiceProvider();
            _weatherService = provider.GetService<WeatherService>();
        }

        [Test]
        public async Task GetWeather_Succeed()
        {
            string countryCode = "ID";
            string cityName = "Makassar";

            var weather = await _weatherService.GetWeatherAsync(countryCode, cityName);

            Assert.IsTrue(weather != null, "Succeed to connect");
            Assert.IsTrue(weather.Status, "Succeed to get response");
            Assert.IsTrue(weather.Entity != null, "Succeed to get response weather");
        }
    }
}