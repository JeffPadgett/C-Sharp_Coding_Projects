using InsuranceWorld.Models;
using System;
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
            private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InsuranceWorld;
                                        Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                        TrustServerCertificate=True;ApplicationIntent=ReadWrite;
                                        MultiSubnetFailover=False";


        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost] // <--- This is called Data Annotations, 
        public ActionResult GetQuote(string firstName, string lastName, string emailAddress,
            string dateOfBirth, int carYear, string carMake,
            string dUI, int speedingTickets, string coverageAnswer)
        {

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
                command.Parameters["@LastName"].Value = lastName;
                command.Parameters["@EmailAddress"].Value = emailAddress;
                command.Parameters["@DateOfBirth"].Value = dateOfBirth;
                command.Parameters["@CarYear"].Value = carYear;
                command.Parameters["@CarMake"].Value = carMake;
                command.Parameters["@DUI"].Value = dUI;
                command.Parameters["@SpeedingTickets"].Value = speedingTickets;
                command.Parameters["@CoverageAnswer"].Value = coverageAnswer;
                int answer = InsuranceQuote.GetQuote(dateOfBirth, carYear, carMake, speedingTickets, dUI, coverageAnswer);
                command.Parameters["@Estimate"].Value = answer;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                

            }

            return View();
        }

        public ActionResult Admin()
        {
            string queryString = @"SELECT Id, FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake, DUI, SpeedingTickets, CoverageAnswer FROM InsuranceWorld";
            List<InsuranceQuote> quotes = new List<InsuranceQuote>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var quote = new InsuranceQuote();
                    quote.Id = Convert.ToInt32(reader["Id"]);
                    quote.FirstName = reader["FirstName"].ToString();
                    quote.EmailAddress = reader["EmailAddress"].ToString();
                    quote.DateOfBirth = reader["DateOfBirth"].ToString();
                    quote.CarYear = Convert.ToInt32(reader["CarYear"]);
                    quote.CarMake = reader["CarMmake"].ToString();
                    quote.CarModel = reader["CarModel"].ToString();
                    quote.DUI = reader["DUI"].ToString();
                    quote.SpeedingTickets = Convert.ToInt32(reader["SpeedingTickets"]);
                    quote.CoverageAnswer = reader["CoverageAnswer"].ToString();
                    quotes.Add(quote);


                }
            }

            return View(quotes);
        }

    }
}