using System.ComponentModel.DataAnnotations;

namespace OptionsPattern.Settings
{
    public class AppSettings
    {
        public Logging Logging { get; set; }
        
        [Required]
        public string AllowedHosts { get; set; }

        [Required]
        public string SomeRequiredConfiguration { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }
}