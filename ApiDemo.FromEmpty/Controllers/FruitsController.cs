using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.FromEmpty.Controllers
{
    [ApiController]
    [Route("fruits")]
    public class FruitsController : ControllerBase
    {
        [HttpGet]
        public string Test()
        {
            return "Test";
        }
        [HttpPost]
        public string Author()
        {
            return "P410";
        }

    }
}
