using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OptionsPattern.Settings;

namespace OptionsPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        public SettingsController(IOptions<AppSettings> options)
        {
            _options = options;
        }

        private readonly IOptions<AppSettings> _options;

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(_options.Value,
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
            }
            catch (OptionsValidationException ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex.Failures));
            }
        }
    }
}
