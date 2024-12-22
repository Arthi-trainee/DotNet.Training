using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    public static class BookingService
    {
        private static string connectionString = "Server=ICS-LT-D244D68Y;Database=TrainReservation;Integrated Security=True;";

        public static void BookTicket()
        {
            try
            {
                Console.Write("Enter Source: ");
                string source = Console.ReadLine();
                Console.Write("Enter Destination: ");
                string destination = Console.ReadLine();
                Console.Write("Enter Journey Date (yyyy-mm-dd): ");
                DateTime journeyDate = Convert.ToDateTime(Console.ReadLine());

               
                if (journeyDate.Date < DateTime.Now.Date)
                {
                    Console.WriteLine("Error: You cannot book tickets for past dates.");
                    return;
                }

                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(
                        "SELECT TrainNo, TrainName, TrainDate, TrainTime, TicketPrice1A, TicketPrice2A, TicketPrice3A, TicketPriceFirstClass, TicketPriceSleeper " +
                        "FROM Trains WHERE Source = @Source AND Destination = @Destination AND TrainDate = @TrainDate AND IsActive = 1",
                        connection);
                    command.Parameters.AddWithValue("@Source", source);
                    command.Parameters.AddWithValue("@Destination", destination);
                    command.Parameters.AddWithValue("@TrainDate", journeyDate);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine("Available Trains:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Train No: {reader["TrainNo"]}, Train Name: {reader["TrainName"]}, Date: {reader["TrainDate"]}, Time: {reader["TrainTime"]}");
                        }
                        reader.Close();

                        
                        Console.Write("Enter Train Number from the available options: ");
                        int trainNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Class (1A, 2A, 3A, First Class, Sleeper): ");
                        string trainClass = Console.ReadLine();
                        Console.Write("Enter Number of Berths to Book: ");
                        int berthsBooked = Convert.ToInt32(Console.ReadLine());

                      
                        decimal ticketPrice = 0;
                        SqlCommand priceCommand = new SqlCommand(
                            "SELECT TicketPrice1A, TicketPrice2A, TicketPrice3A, TicketPriceFirstClass, TicketPriceSleeper FROM Trains WHERE TrainNo = @TrainNo",
                            connection);
                        priceCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                        SqlDataReader priceReader = priceCommand.ExecuteReader();

                        if (priceReader.HasRows)
                        {
                            priceReader.Read();
                            switch (trainClass)
                            {
                                case "1A": ticketPrice = priceReader.GetDecimal(0); break;
                                case "2A": ticketPrice = priceReader.GetDecimal(1); break;
                                case "3A": ticketPrice = priceReader.GetDecimal(2); break;
                                case "First Class": ticketPrice = priceReader.GetDecimal(3); break;
                                case "Sleeper": ticketPrice = priceReader.GetDecimal(4); break;
                                default:
                                    Console.WriteLine("Invalid Class.");
                                    return;
                            }
                        }
                        priceReader.Close();

                       
                        decimal totalCost = ticketPrice * berthsBooked;

                        
                        Console.Write("Enter Passenger Name: ");
                        string passengerName = Console.ReadLine();

                       
                        SqlCommand bookCommand = new SqlCommand("BookTicket", connection);
                        bookCommand.CommandType = CommandType.StoredProcedure;
                        bookCommand.Parameters.AddWithValue("@TrainNo", trainNo);
                        bookCommand.Parameters.AddWithValue("@PassengerName", passengerName); 
                        bookCommand.Parameters.AddWithValue("@Class", trainClass);
                        bookCommand.Parameters.AddWithValue("@BerthsBooked", berthsBooked);
                        bookCommand.Parameters.AddWithValue("@JourneyDate", journeyDate);
                        bookCommand.Parameters.AddWithValue("@TrainDate", journeyDate); 
                        bookCommand.Parameters.AddWithValue("@TrainTime", DateTime.Now.TimeOfDay); 
                        bookCommand.Parameters.AddWithValue("@TotalCost", totalCost);

                        bookCommand.ExecuteNonQuery();
                        Console.WriteLine("Ticket booked successfully! Total Cost of the ticket is " + totalCost);
                    }
                    else
                    {
                        Console.WriteLine("No trains available for the given criteria.");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public static void CancelTicket()
        {
            try
            {
                Console.Write("Enter Booking ID to Cancel: ");
                int bookingID = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("CancelTicket", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@BookingID", bookingID);

               
                    SqlParameter refundParam = new SqlParameter("@RefundAmount", SqlDbType.Decimal)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(refundParam);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        decimal refundAmount = (decimal)refundParam.Value;
                        Console.WriteLine($"Cancellation successful. Refund amount after 15% deduction: {refundAmount}");
                    }
                    else
                    {
                        Console.WriteLine("Cancellation failed: Invalid Booking ID or ticket already cancelled.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cancelling ticket: {ex.Message}");
            }
        }



        public static void ShowAllTrains()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("ShowAllTrains", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\nAvailable Trains:\n");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("| Train No | Train Name        | Source      | Destination   | 1A | 2A | 3A | First Class | Sleeper | Date       | Time   |");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine($"| {reader["TrainNo"],-8} | {reader["TrainName"],-15} | {reader["Source"],-10} | {reader["Destination"],-12} | " +
                                              $"{reader["Available1A"],3} | {reader["Available2A"],3} | {reader["Available3A"],3} | " +
                                              $"{reader["AvailableFirstClass"],11} | {reader["AvailableSleeper"],7} | " +
                                              $"{reader["TrainDate"],-10} | {reader["TrainTimeInAMPM"],-6} |");
                        }

                        Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching train details: {ex.Message}");
            }
        }

        public static void ShowAllBookings()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("ShowAllBookings", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("\nBooking Details:");
                                while (reader.Read())
                                {
                                    Console.WriteLine($"Booking ID: {reader["BookingID"]}");
                                    Console.WriteLine($"Train No: {reader["TrainNo"]}");
                                    Console.WriteLine($"Passenger: {reader["PassengerName"]}");
                                    Console.WriteLine($"Class: {reader["Class"]}");
                                    Console.WriteLine($"Berths Booked: {reader["BerthsBooked"]}");
                                    Console.WriteLine($"Journey Date: {Convert.ToDateTime(reader["JourneyDate"]):yyyy-MM-dd}");
                                    Console.WriteLine($"Status: {reader["Status"]}");
                                    Console.WriteLine("-----------------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No bookings found.");
                            }
                        }
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


