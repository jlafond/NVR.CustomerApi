using NVR.CustomerApi.DataLayer.Interfaces;
using NVR.CustomerApi.Services.Interfaces;
using NVR.CustomerApi.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVR.CustomerApi.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerModel> GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            return customers.Select(x => CustomerModel.From(x)).ToList();
        }

        public bool SaveCustomer(CustomerModel customer)
        {
            return _customerRepository.SaveCustomer(CustomerModel.To(customer));
        }
    }
}
