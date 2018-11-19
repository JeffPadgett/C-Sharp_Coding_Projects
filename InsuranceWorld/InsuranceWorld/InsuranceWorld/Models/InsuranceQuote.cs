using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceWorld.Models
{
    public class InsuranceQuote
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string DUI { get; set; }
        public int SpeedingTickets { get; set; }
        public string CoverageAnswer { get; set; }
        public Decimal Estimate { get; set; }


        public static decimal GetQuote(string dateOfBirth, int carYear, string carMake, int speedingTickets, string dUI, string coverageAnswer )
        {
            int quoteStart = 50;
            DateTime currentDate = DateTime.Now;
            int userAge = Convert.ToInt16(currentDate.Year - Convert.ToDateTime(dateOfBirth).Year);
            int speedingPrice = speedingTickets * 10;
            string dUIAnswer = dUI.ToLower();
            string coverageType = coverageAnswer.ToLower();
            string carType = carMake.ToLower();
            decimal quote;


            if (userAge < 25 && userAge > 18)
                quoteStart += 25;
            else if (userAge < 18)
                quoteStart += 100;
            else if (userAge > 100)
                quoteStart += 25;

            if (carYear < 2000)
                quoteStart += 25;
            else if (carYear > 2015)
                quoteStart += 25;

            if (carType == "porsche")
                quoteStart += 25;
            else if (carType == "porsche" && carType == "911 carrera")
                quoteStart += 25;

            quote = Convert.ToDecimal(quoteStart);

            if (dUIAnswer == "yes" || dUIAnswer == "ya")
            {
                quote += (25 / 100) * quote;            
            }

            if (coverageType == "full coverage")
                quote += (50 / 100) * quote; ;

           
           return quote;

        }
    }
}