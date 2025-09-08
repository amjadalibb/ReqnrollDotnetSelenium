using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollDotnetSelenium.Helpers
{
    public class appSettings
    {
        // Method to get application settings from appsettings.json
        public static string? GetAppSettings(string xPath)
        {
            var jsonPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Config\\appsettings.json");
            var config = new ConfigurationBuilder().AddJsonFile(jsonPath).Build();
            return config[xPath];
        }
    }
}
