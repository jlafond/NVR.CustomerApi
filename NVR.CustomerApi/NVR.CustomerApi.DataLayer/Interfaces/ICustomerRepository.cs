using NVR.CustomerApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NVR.CustomerApi.DataLayer.Interfaces
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomers();

        public bool SaveCustomer(Customer customer);
    }
}
