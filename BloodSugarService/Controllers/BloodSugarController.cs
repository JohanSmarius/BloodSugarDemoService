using BloodSugarService.Model;
using Microsoft.AspNetCore.Mvc;

namespace BloodSugarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloodSugarController :  ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var measurements = new List<BloodSugarMeasurement>();

            for (int i = 0; i < 5; i++)
            {
                var random = new Random();

                var date = DateTime.Today.AddDays(-i);

                for (int moments = 0; moments < 10; moments++)
                {
                    var value = random.Next(30, 100) / 10.0m;
                    var remark = random.Next(0, 10) > 7 ? "Auto generated remark" : null;

                    var randomHour = random.Next(0, 24);

                    var moment = new DateTime(date.Year, date.Month, date.Day, randomHour, 0, 0);

                    measurements.Add(new BloodSugarMeasurement(moment, value, remark));

                }

            }

            return Ok(measurements);

        }
    }
}
