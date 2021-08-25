using NVR.CustomerApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NVR.CustomerApi.Services.Interfaces
{
    public interface ICustomerService
    {
        public object GetCustomers();
        public bool SaveCustomer(CustomerModel customer);
    }
}
