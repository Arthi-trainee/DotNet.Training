using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem
{
    public static class User
    {
        public static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu");
                Console.WriteLine("1. Book Ticket\n2. Cancel Ticket\n3. Show All Trains\n4. Show All Bookings/Cancellations\n5. Exit");
                Console.Write("Choose an option: ");
                int result = Convert.ToInt32(Console.ReadLine());

                switch (result)
                {
                    case 1:
                        BookingService.BookTicket();
                        break;
                    case 2:
                        BookingService.CancelTicket();
                        break;
                    case 3:
                        BookingService.ShowAllTrains();
                        break;
                    case 4:
                        BookingService.ShowAllBookings();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }
    }
}
