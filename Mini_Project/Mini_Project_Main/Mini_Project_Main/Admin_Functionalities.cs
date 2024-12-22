using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    public static class TrainService
    {
        private static string connectionString = "Server=ICS-LT-D244D68Y;Database=TrainReservation;Integrated Security=True;";

        public static void AddTrain()
        {
            try
            {
                Console.Write("Enter Train Number: ");
                int trainNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Train Name: ");
                string trainName = Console.ReadLine();
                Console.Write("Enter Total Berths for 1A: ");
                int total1A = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Ticket Price for 1A: ");
                decimal ticketPrice1A = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Total Berths for 2A: ");
                int total2A = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Ticket Price for 2A: ");
                decimal ticketPrice2A = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Total Berths for 3A: ");
                int total3A = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Ticket Price for 3A: ");
                decimal ticketPrice3A = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Total Berths for First Class: ");
                int totalFirstClass = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Ticket Price for First Class: ");
                decimal ticketPriceFirstClass = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Total Berths for Sleeper: ");
                int totalSleeper = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Ticket Price for Sleeper: ");
                decimal ticketPriceSleeper = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Source: ");
                string source = Console.ReadLine();
                Console.Write("Enter Destination: ");
                string destination = Console.ReadLine();
                Console.Write("Enter Train Date (yyyy-mm-dd): ");
                DateTime trainDate = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter Train Time (hh:mm:ss): ");
                TimeSpan trainTime = TimeSpan.Parse(Console.ReadLine());

               
                string formattedTime = DateTime.Today.Add(trainTime).ToString("hh:mm tt");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("AddTrain", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TrainNo", trainNo);
                    command.Parameters.AddWithValue("@TrainName", trainName);
                    command.Parameters.AddWithValue("@Total1A", total1A);
                    command.Parameters.AddWithValue("@Total2A", total2A);
                    command.Parameters.AddWithValue("@Total3A", total3A);
                    command.Parameters.AddWithValue("@TotalFirstClass", totalFirstClass);
                    command.Parameters.AddWithValue("@TotalSleeper", totalSleeper);
                    command.Parameters.AddWithValue("@Source", source);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@TicketPrice1A", ticketPrice1A);
                    command.Parameters.AddWithValue("@TicketPrice2A", ticketPrice2A);
                    command.Parameters.AddWithValue("@TicketPrice3A", ticketPrice3A);
                    command.Parameters.AddWithValue("@TicketPriceFirstClass", ticketPriceFirstClass);
                    command.Parameters.AddWithValue("@TicketPriceSleeper", ticketPriceSleeper);
                    command.Parameters.AddWithValue("@TrainDate", trainDate);
                    command.Parameters.AddWithValue("@TrainTime", trainTime);

       
                    command.ExecuteNonQuery();
                    Console.WriteLine("Train Added Successfully! The Train Time is " + formattedTime);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



        public static void ModifyTrain()
        {
            try
            {
                Console.Write("Enter Train Number to Modify: ");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Train Name: ");
                string trainName = Console.ReadLine();
                Console.Write("Enter New Source: ");
                string source = Console.ReadLine();
                Console.Write("Enter New Destination: ");
                string destination = Console.ReadLine();

                Console.Write("Enter New Ticket Price for 1A: ");
                decimal ticketPrice1A = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter New Ticket Price for 2A: ");
                decimal ticketPrice2A = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter New Ticket Price for 3A: ");
                decimal ticketPrice3A = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter New Ticket Price for First Class: ");
                decimal ticketPriceFirstClass = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter New Ticket Price for Sleeper: ");
                decimal ticketPriceSleeper = Convert.ToDecimal(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("ModifyTrain", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TrainNo", trainNo);
                    command.Parameters.AddWithValue("@TrainName", trainName);
                    command.Parameters.AddWithValue("@Source", source);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@TicketPrice1A", ticketPrice1A);
                    command.Parameters.AddWithValue("@TicketPrice2A", ticketPrice2A);
                    command.Parameters.AddWithValue("@TicketPrice3A", ticketPrice3A);
                    command.Parameters.AddWithValue("@TicketPriceFirstClass", ticketPriceFirstClass);
                    command.Parameters.AddWithValue("@TicketPriceSleeper", ticketPriceSleeper);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Train Modified Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No active train found with that number.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void DeleteTrain()
        {
            try
            {
                Console.Write("Enter Train Number to Delete: ");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteTrain", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TrainNo", trainNo);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Train Deleted Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No active train found with that number.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}


