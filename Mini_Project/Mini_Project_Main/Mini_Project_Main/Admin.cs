using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem
{
    public static class Admin
    {
        public static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu");
                Console.WriteLine("1. Add Train\n2. Modify Train\n3. Delete Train \n4. Exit");
                Console.Write("Choose an option: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        TrainService.AddTrain();
                        break;
                    case 2:
                        TrainService.ModifyTrain();
                        break;
                    case 3:
                        TrainService.DeleteTrain();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }
    }
}
