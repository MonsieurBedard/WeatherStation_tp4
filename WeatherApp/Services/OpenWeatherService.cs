using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.ViewModels;

namespace WeatherApp.Services
{
    class OpenWeatherService : ITemperatureService
    {
        private OpenWeatherProcessor owp = OpenWeatherProcessor.Instance;

        public TemperatureModel LastTemp { get; private set; }

        public OpenWeatherService(string apiKey)
        {
            owp.ApiKey = apiKey;
            LastTemp = new TemperatureModel();
        }

        public async Task<TemperatureModel> GetTempAsync()
        {
            OpenWeatherOneCallModel model = await owp.GetOneCallAsync();
            LastTemp.DateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            LastTemp.DateTime = LastTemp.DateTime.AddSeconds(model.Current.DateTime);
            LastTemp.DateTime = LastTemp.DateTime.ToLocalTime();
            LastTemp.Temperature = model.Current.Temperature;

            return LastTemp;
        }
    }
}
