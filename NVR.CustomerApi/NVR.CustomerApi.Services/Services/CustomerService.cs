using NVR.CustomerApi.Services.Interfaces;
using NVR.CustomerApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NVR.CustomerApi.Services.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService() { }

        public object GetCustomers()
        {
            return new object[1];
        }

        public bool SaveCustomer(CustomerModel customer)
        {
            return true;
        }
    }
}
