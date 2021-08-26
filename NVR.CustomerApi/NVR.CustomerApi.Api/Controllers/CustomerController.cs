using Microsoft.AspNetCore.Mvc;
using NVR.CustomerApi.Services.Models;
using NVR.CustomerApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace NVR.CustomerApi.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        public ICustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var customers = _customerService.GetCustomers();
                return Ok(customers);
            }
            catch(Exception e)
            {
                _logger.LogError("Unable to retrieve customers", e);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody]CustomerModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_customerService.SaveCustomer(customer))
            {
                return Ok();
            }
            _logger.LogError("Unable to save customer");
            return StatusCode(500);
        }
    }
}
