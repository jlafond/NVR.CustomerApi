using System;
using System.Collections.Generic;
using System.Text;

namespace NVR.CustomerApi.DataLayer.Entities
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
