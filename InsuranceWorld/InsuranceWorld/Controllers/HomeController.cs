﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        // This amount of parameters is uncomfortable and looks messy, I am going to refactor this method after the database implamentation.
        [HttpPost] // <--- This is called Data Annotations, 
        public ActionResult GetQuote(string firstName, string lastName, string emailAddress,
            string dateOfBirth, int carYear, string carMake,
            string dUI, int speedingTickets, string coverageAnswer)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InsuranceWorld;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=True;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";

            string queryString = @"INSERT INTO InsuranceWorld (FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake, DUI, SpeedingTickets, CoverageAnswer";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);
                command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                command.Parameters.Add("@DateOfBirth", SqlDbType.VarChar);
                command.Parameters.Add("@CarYear", SqlDbType.Int);
                command.Parameters.Add("@CarMake", SqlDbType.VarChar);
                command.Parameters.Add("@DUI", SqlDbType.VarChar);
                command.Parameters.Add("@SpeedingTickets", SqlDbType.Int);
                command.Parameters.Add("@CoverageAnswer", SqlDbType.VarChar);

                command.Parameters["@FirstName"].Value = firstName;
                command.Parameters["@FirstName"].Value = lastName;
                command.Parameters["@FirstName"].Value = emailAddress;
                command.Parameters["@FirstName"].Value = dateOfBirth;
                command.Parameters["@FirstName"].Value = carYear;
                command.Parameters["@FirstName"].Value = carMake;
                command.Parameters["@FirstName"].Value = dUI;
                command.Parameters["@FirstName"].Value = speedingTickets;
                command.Parameters["@FirstName"].Value = coverageAnswer;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                

            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}