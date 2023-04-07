namespace CalculationUI
{
    internal class ConfigOptions : IConfigOptions
    {
        private readonly IConfiguration _configuration;

        public ConfigOptions(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetAPIBaseURL()
        {
            return _configuration["APIBaseURL"];
        }
    }
}
