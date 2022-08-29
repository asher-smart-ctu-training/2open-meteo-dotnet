﻿using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMeteo;

namespace OpenMeteoTests
{
    [TestClass]
    public class WeatherForecastTests
    {
        [TestMethod]
        public async Task Only_Location_Name_Test()
        {
            OpenMeteoClient client = new OpenMeteoClient();
            string location = "Tokyo";
            WeatherForecast weatherData = await client.QueryAsync(location);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);
        }

        [TestMethod]
        public async Task Latitude_Longitude_Test()
        {
            OpenMeteoClient client = new OpenMeteoClient();
            
            WeatherForecast weatherData = await client.QueryAsync(1f, 2f);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);

            Assert.AreEqual(1f, weatherData.Latitude);
            Assert.AreEqual(2f, weatherData.Longitude);
        }

        [TestMethod]
        public async Task GeocodingOptions_Test()
        {
            OpenMeteoClient client = new OpenMeteoClient();
            GeocodingOptions options = new GeocodingOptions("Tokyo");
            WeatherForecast weatherData = await client.QueryAsync(options);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);
        }

        [TestMethod]
        public async Task Only_Location_Name_test()
        {
            OpenMeteoClient client = new OpenMeteoClient();
            string location = "Tokyo";
            WeatherForecast weatherData = await client.QueryAsync(location);

            Assert.IsNotNull(weatherData);
            Assert.IsNotNull(weatherData.Longitude);
            Assert.IsNotNull(weatherData.Latitude);
        }
    }
}