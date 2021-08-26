using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NVR.CustomerApi.DataLayer.Entities
{
    public class Customer
    {
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        
        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
