using NVR.CustomerApi.Services.Models;
using System.Collections.Generic;

namespace NVR.CustomerApi.Services.Interfaces
{
    public interface ICustomerService
    {
        public List<CustomerModel> GetCustomers();
        public bool SaveCustomer(CustomerModel customer);
    }
}
