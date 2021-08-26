using Newtonsoft.Json;
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
        public List<Customer> GetCustomers()
        {
            return ReadFromFile();
        }

        public bool SaveCustomer(Customer customer)
        {
            var serialized = JsonConvert.SerializeObject(customer);

            return WriteToFile(serialized);
        }

        private List<Customer> ReadFromFile()
        {
            try
            {
                using (StreamReader file = new StreamReader("Path.json"))
                {
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(file.ReadToEnd());
                    return customers;
                }
            }
            catch(Exception e)
            {
                //log error
                return new List<Customer>();
            }
        }

        private bool WriteToFile(string json)
        {
            try
            {
                System.IO.File.WriteAllText(@"D:\path.txt", json);
                return true;
            }
            catch (Exception e)
            {
                //log error
                return false;
            }
        }

    }
}
