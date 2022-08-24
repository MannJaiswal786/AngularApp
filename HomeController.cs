using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIClass1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet("get")]
        public string Get()
        {
            return "Welcome to API Course";
        }

        [HttpGet("getById/{id}")]
        public string GetById(int id)
        {
            return "Your id is: " + id;
        }

    }
}
