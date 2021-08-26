using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NVR.CustomerApi.DataLayer.Entities;
using NVR.CustomerApi.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NVR.CustomerApi.DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;
        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;
        }

        private List<Customer> _customers;
        public List<Customer> GetCustomers() => _customers != null ? _customers : _customers = ReadFromFile() ?? new List<Customer>();

        public bool SaveCustomer(Customer customer)
        {
            GetCustomers().Add(customer);

            var serialized = JsonConvert.SerializeObject(_customers);

            return WriteToFile(serialized);
        }

        private string GetFilePath()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "customers.txt");
            return Path.Combine(Environment.CurrentDirectory, "customers.txt");
        }

        private List<Customer> ReadFromFile()
        {
            try
            {
                using (StreamReader file = new StreamReader(GetFilePath()))
                {
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(file.ReadToEnd());

                    return customers;
                }
            }
            catch(Exception e)
            {
                _logger.LogError("Error ocurred while retrieving customers.", e);
                return new List<Customer>();
            }
        }

        private bool WriteToFile(string json)
        {
            try
            {
                System.IO.File.WriteAllText(GetFilePath(), json);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("Error ocurred while saving customer.", e);
                return false;
            }
        }

    }
}
