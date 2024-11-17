using System;
using CalculatorLibrary;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter user name:");

            string user_name = Console.ReadLine();

            Console.WriteLine("Enter Age of the user:");

            int user_age = Convert.ToInt32(Console.ReadLine());

            Class1 calc_lib_obj= new Class1();

            calc_lib_obj.CalculateConcession(user_name, user_age);

            Console.Read();

        }
    }
}
