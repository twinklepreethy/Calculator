using Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConfigurationService : IConfigurationService
    {
        private IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .Build();
        }

        public string GetLogFilePath()
        {
            return GetConfig().GetValue<string>("LogFilePath");
        }
    }
}
