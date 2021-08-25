using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVR.CustomerApi.Api.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController()
        {

        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddCustomer()
        {
            return Ok();
        }


    }
}
