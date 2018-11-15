using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceQuoteGenerator.Models
{
    public class InsuranceQuote
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int DUI { get; set; } //In the database 1 will be stored as yes, 2 will be stored as no along with a reference ID
        public int AquiredTickets { get; set; }
        public bool FullCoverage { get; set; }

    }
}