using Newtonsoft.Json;
using NVR.CustomerApi.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NVR.CustomerApi.Services.Models
{
    public class CustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public static Customer To(CustomerModel customer)
        {
            return new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber
            };
        }

        public static CustomerModel From(Customer customer)
        {
            return new CustomerModel()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber
            };
        }

    }
}
