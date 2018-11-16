using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceQuoteGenerator.ViewModels
{
    public class InsuranceQuoteViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int DUI { get; set; }
        public IEnumerable<DUI> DUIAnswer { get; set; }
        public int AquiredTickets { get; set; }
        public bool FullCoverage { get; set; }
    }
}