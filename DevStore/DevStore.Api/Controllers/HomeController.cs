using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : Controller
    {
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }
    }
}