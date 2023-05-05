using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfYuccaMoths
{
    enum WeatherType
    {
        Sunny,
        Cloudy,
        Rainy
    }

    class WeatherEvent
    {
        public static WeatherType CurrentWeather = WeatherType.Sunny;

        public WeatherType GetWeather()
        {
            int num = Utility.RandomNumber.Next(Enum.GetNames(typeof(WeatherType)).Length);
            CurrentWeather = (WeatherType)num;
            return CurrentWeather;
        }
    }
}
