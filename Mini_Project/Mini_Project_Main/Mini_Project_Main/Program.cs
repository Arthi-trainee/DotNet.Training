using System;
using System.Data;
using System.Data.SqlClient;

namespace TrainReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Train Reservation System");

            while (true)
            {
                Console.WriteLine("\n1. Admin\n2. User\n3. Exit");
                Console.Write("Choose an option: ");
                int result = Convert.ToInt32(Console.ReadLine());

                switch (result)
                {
                    case 1:
                        if (Admin_Validation()) 
                        {
                            Admin.ShowMenu(); 
                        }
                        else
                        {
                            Console.WriteLine("Access denied! Invalid username or password.");
                        }
                        break;
                    case 2:
                        User.ShowMenu();
                        break;
                    case 3:
                        return; 
                    default:
                        Console.WriteLine("Invalid Option! Try again.");
                        break;
                }
            }
        }

        private static bool Admin_Validation()
        {
            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

           
            return ValidateAdmin(username, password);
        }

        private static bool ValidateAdmin(string username, string password)
        {
            string connectionString = "Server=ICS-LT-D244D68Y;Database=TrainReservation;Integrated Security=True;"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ValidateAdmin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read() && reader["Status"].ToString() == "Valid")
                    {
                        return true;
                    }
                }
            }
            return false; 
        }
    }
}

