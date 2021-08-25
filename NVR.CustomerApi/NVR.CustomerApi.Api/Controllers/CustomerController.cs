using Microsoft.AspNetCore.Mvc;
using NVR.CustomerApi.Services.Models;
using NVR.CustomerApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVR.CustomerApi.Api.Controllers
{
    public class CustomerController : Controller
    {
        public ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerModel customer)
        {
            var saveSuccess = _customerService.SaveCustomer(customer);
            if (saveSuccess)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
