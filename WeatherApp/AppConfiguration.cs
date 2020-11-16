using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WeatherApp
{
    static class AppConfiguration
    {
        private static IConfiguration configuration;

        public static string GetValue(string str)
        {
            if (configuration == null)
            {
                initConfig();
            }

            return $"{configuration[ str ]}";
        }

        private static void initConfig()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            builder.AddUserSecrets<MainWindow>();
            configuration = builder.Build();
        }
    }
}
