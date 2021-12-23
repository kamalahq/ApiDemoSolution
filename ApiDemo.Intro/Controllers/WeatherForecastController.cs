using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Intro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        static string[] fruits = { "Alma", "Armud", "Nar" };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return fruits;
        }
    }
}
